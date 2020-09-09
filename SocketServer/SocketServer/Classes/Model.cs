using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Classes
{
    class Model : IModel
    {
        IView view;

        public void ClientDataReceived(object receivedData, TypeCode type, string requestType)
        {
            var value = Convert.ChangeType(receivedData, type);
            view.AppendLog("[+]Received data[+] \nValue: " + value.ToString() + "\nType: " + type.ToString() + "\nAdditional Requestinfo: " + requestType + "\n");
        }

        public void SetView(IView view)
        {
            this.view = view;
        }
    }
}
