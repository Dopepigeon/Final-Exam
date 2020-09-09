using System;
using System.Collections.Generic;

namespace TemperaturClient
{
    public class Controller : IController
    {
        string ip = "127.0.0.1";
        int port = 11000;

        IModel model;

        public List<Temperatur> GetDataFromServer(DateTime start, DateTime end)
        {
            AsyncSocketClient asyncSocketClient = new AsyncSocketClient(ip, port);
            return asyncSocketClient.GetTempRange(start, end);
        }

        public void SetModel(IModel model)
        {
            this.model = model;
        }
    }
}