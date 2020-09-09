using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Interfaces
{
    public interface IController
    {
        void SetUpServer(IPAddress ipaddress, int port);
        void SetModel(IModel model);
        void SetView(IView view);
        void StopServer();
    }
}
