using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.Text;

namespace TemperaturClient
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

    public class AsyncSocketClient
    {
        private Socket client;
        private IPEndPoint remoteEp;

        public AsyncSocketClient(string ipAddress, int port)
        {
            remoteEp = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        }

        public bool SendData<T>(T data, string additionalData = "")
        {
            Request request = new Request();
            //set datatype to the typecode of the datatype
            request.dataType = Type.GetTypeCode(typeof(T));
            request.value = data;
            request.requestType = additionalData;
            return SendObject<Request>(request);
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

        public List<Temperatur> GetTempRange(DateTime start, DateTime end)
        {
            bool error = false;
            List<Temperatur> temp = new List<Temperatur>();

            try
            {
                client = new Socket(remoteEp.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.NoDelay = true;

                // Connect to the remote endpoint.  
                client.Connect(remoteEp);

                if (!error)
                {
                    //SendReqType
                    client.Send(BitConverter.GetBytes((int)RequestType.GetDataRange));

                    RangeRequest rangeReq = new RangeRequest();
                    rangeReq.start = start;
                    rangeReq.end = end;

                    SendString(client, JsonConvert.SerializeObject(rangeReq));

                    temp = JsonConvert.DeserializeObject<List<Temperatur>>(ReadString(client));
                    
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch (Exception e)
            {
                error = true;
            }
            return temp;
        }

        public bool SendObject<T>(T request)
        {
            bool error = false;

            try
            {
                client = new Socket(remoteEp.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.NoDelay = true;

                // Connect to the remote endpoint.  
                client.Connect(remoteEp);

                if (!error)
                {
                    //SendReqType
                    client.Send(BitConverter.GetBytes(0));

                    //serialize struct data to string
                    string objectString = JsonConvert.SerializeObject(request);

                    SendString(client, objectString);

                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch (Exception e)
            {
                error = true;
            }
            return error;
        }
    }
}
