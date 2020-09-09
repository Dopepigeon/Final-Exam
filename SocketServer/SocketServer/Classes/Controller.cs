using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Classes
{
    class Controller : IController
    {
        AsyncSocketListener listener;
        IModel model;
        IView view;

        public void SetModel(IModel model)
        {
            this.model = model;
        }

        public void SetView(IView view)
        {
            this.view = view;
        }

        public void SetUpServer(IPAddress ipAddress, int port)
        {
            listener = new AsyncSocketListener();
            listener.StartListening(ipAddress, port, System.Net.Sockets.ProtocolType.Tcp, view);
        }

        public void StopServer()
        {
            if (listener != null)
            {
                listener.StopServer();
            }
        }
    }
}
