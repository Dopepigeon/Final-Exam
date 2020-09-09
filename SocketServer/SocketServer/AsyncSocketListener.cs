using Newtonsoft.Json;
using SocketServer.Classes;
using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketServer
{
    public enum RequestType
    {
        GetDataRange,
        Default
    }

    //Serializable so JsonConvert.SerializeObject can serialize the struct object 
    [Serializable]
    public struct Request
    {
        //this field represents the datatype of the object
        public TypeCode dataType;

        //this field represents the object value
        public object value;

        //this field can be used for additional information for example as what to do with the data
        public string requestType;
    }

    [Serializable]
    public struct Temperatur
    {
        public double temp;
        public DateTime dateTime;

        public Temperatur(double temp, DateTime dateTime)
        {
            this.temp = temp;
            this.dateTime = dateTime;
        }
    }

    [Serializable]
    public struct RangeRequest
    {
        public DateTime start;
        public DateTime end;
    }

    class AsyncSocketListener
    {
        public bool keepRunning = true;
        public Thread listenerThread;
        public ManualResetEvent allDone = new ManualResetEvent(false);
        public Socket listenerGlobal;
        public IView view;

        public void StartListening(IPAddress ipAddress, int port, ProtocolType type, IView view)
        {
            this.view = view;
            keepRunning = true;

            if (listenerThread == null)
            {
                listenerThread = new Thread(() => StartServer(ipAddress, port, type));
                listenerThread.Start();
            }
            else
            {
                if (!listenerThread.IsAlive)
                {
                    listenerThread = new Thread(() => StartServer(ipAddress, port, type));
                    listenerThread.Start();
                }
            }
        }

        public void StopServer()
        {
            keepRunning = false;

            if (listenerGlobal != null)
            {
                //verbindung schließen falls noch jemand verbunden ist
                try
                {
                    listenerGlobal.Disconnect(false);
                    listenerGlobal.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                }

                //socket schließen
                try
                {
                    listenerGlobal.Close();
                    listenerGlobal.Dispose();
                }
                catch (Exception ex)
                {
                }
            }

            if (listenerThread != null)
            {
                try
                {
                    if (listenerThread.IsAlive)
                    {
                        //stop the thread
                        listenerThread.Abort();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void StartServer(IPAddress ipAddress, int port, ProtocolType type)
        {
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            listenerGlobal = new Socket(ipAddress.AddressFamily, SocketType.Stream, type);

            try
            {
                listenerGlobal.Bind(localEndPoint);
                //Backlog 200
                listenerGlobal.Listen(200);

                while (keepRunning)
                {
                    allDone.Reset();
                    // Start an asynchronous socket to listen for connections.  
                    listenerGlobal.BeginAccept(new AsyncCallback(AcceptCallback), listenerGlobal);
                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
            }
        }

        private void SendString(Socket client, string objectString)
        {
            //get byte[] from string
            byte[] stringarray = Encoding.ASCII.GetBytes(objectString);

            //get byte[] for string lenght
            byte[] stringLenght = BitConverter.GetBytes(stringarray.Length);

            //send string lenght to server 
            client.Send(stringLenght);

            //send string bytes to server
            client.Send(stringarray);
        }

        private string ReadString(Socket handler)
        {
            //get lenght of string to receive
            byte[] lenghtBuffer = ReadBytes(4, handler);
            int amountBytes = BitConverter.ToInt32(lenghtBuffer, 0);

            //get string bytes
            byte[] stringBuffer = ReadBytes(amountBytes, handler);

            //convert string bytes to string
            return Encoding.ASCII.GetString(stringBuffer, 0, stringBuffer.Length);
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                // Signal the main thread to continue.  
                allDone.Set();

                // Get the socket that handles the client request.  
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                //get requestType
                byte[] lenghtBuffer = ReadBytes(4, handler);
                RequestType requestType = (RequestType)BitConverter.ToInt32(lenghtBuffer, 0);

                if (requestType == RequestType.GetDataRange)
                {
                    //deserialize string to request object
                    RangeRequest request = JsonConvert.DeserializeObject<RangeRequest>(ReadString(handler));

                    var listRes = Database.GetTempRange(request.start, request.end);

                    view.AppendLog($"[+] TEMPERATURE RANGE REQUEST [+]\n Start: {request.start.ToShortDateString()} {request.start.ToLongTimeString()} \n End: {request.end.ToShortDateString()} {request.start.ToLongTimeString()}\n Sent {listRes.Count} Temperaturepoints back ! \n");

                    SendString(handler, JsonConvert.SerializeObject(listRes));
                }
                else
                {
                    //deserialize string to request object
                    Request request = JsonConvert.DeserializeObject<Request>(ReadString(handler));
                }
            }
            catch (Exception ex) { }
        }

        private static byte[] ReadBytes(int amountBytes, Socket socket)
        {
            int received = 0;
            byte[] buffer = new byte[amountBytes];
            while (received < amountBytes)
            {
                //receive bytes until requested amount of bytes has been received
                received += socket.Receive(buffer: buffer, offset: received, size: amountBytes - received, socketFlags: SocketFlags.None);
            }
            return buffer;
        }
    }
}
