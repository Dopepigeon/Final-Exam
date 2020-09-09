using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer.Interfaces
{
    public interface IView
    {
        void SetController(IController controller);
        void SetGuiReference(FormMain mainForm);
        void AppendLog(string data);
    }
}
