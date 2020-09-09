using SocketServer.Classes;
using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using View = SocketServer.Classes.View;

namespace SocketServer
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IModel model = new Model();
            IController controller = new Controller();
            IView view = new View();

            view.SetController(controller);
            controller.SetModel(model);
            controller.SetView(view);
            model.SetView(view);

            FormMain mainForm = new FormMain(view, model, controller);
            view.SetGuiReference(mainForm);

            Application.Run(mainForm);
        }
    }
}
