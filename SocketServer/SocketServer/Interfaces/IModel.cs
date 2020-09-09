using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Interfaces
{
    public interface IModel
    {
         void ClientDataReceived(object receivedData, TypeCode type, string requestType);
         void SetView(IView view);
    }
}
