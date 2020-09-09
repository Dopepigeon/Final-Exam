using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer.Classes
{
    public class View : IView
    {
        IController controller;

        FormMain formMain;

        public void SetController(IController controller)
        {
            this.controller = controller;
        }

        public void SetGuiReference(FormMain mainForm)
        {
            formMain = mainForm;
        }

        public void AppendLog(string data)
        {
            formMain.BeginInvoke(new MethodInvoker(delegate () { formMain.richTextBoxLog.Text += data + "\n"; }));
            formMain.BeginInvoke(new MethodInvoker(delegate () { formMain.richTextBoxLog.SelectionStart = formMain.richTextBoxLog.Text.Length; }));
            formMain.BeginInvoke(new MethodInvoker(delegate () { formMain.richTextBoxLog.ScrollToCaret(); }));
        }
    }
}
