using SocketServer.Classes;
using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class AsyncSerialListener
    {
        private SerialPort sp;
        private string port;
        private IView view;

        public AsyncSerialListener(string port, IView view)
        {
            this.view = view;
            this.port = port;
        }

        public void StartSerial()
        {
            try
            {
                SetupSerial(this.port);
            }
            catch (Exception) { }
        }

        public void StopSerial()
        {
            try
            {
                sp.Close();
                sp.Dispose();
            }
            catch (Exception) { }
        }

        private void SetupSerial(string port)
        {
            //init SerialPort --> slower baud so it is easier to save
            sp = new SerialPort(port, 2400, Parity.None, 8, StopBits.One);

            //subscripe event (fired when data is being received)
            sp.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            sp.Open();
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //read string with escape delimiter
            string readString = ReadStringWithDelimeter();

            try
            {
                double number = double.Parse(readString, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
                Database.SaveTemp(new Temperatur(number, DateTime.Now));
                view.AppendLog($"GOT NUMBER FROM SERIAL: {number}");
            }
            catch (Exception) { }
        }

        private string ReadStringWithDelimeter()
        {
            int lastChar;
            string builtString = "";
            bool gotDelimeter = false;

            while (!gotDelimeter)
            {
                //read char
                lastChar = sp.ReadChar();

                //cast int char code to char
                char converted = (char)lastChar;

                if (converted == '^')
                {
                    //stop reading delimiter received -> string ended
                    gotDelimeter = true;
                }
                else
                {
                    //append char to string
                    builtString += converted.ToString();
                }
            }
            return builtString;
        }
    }
}
