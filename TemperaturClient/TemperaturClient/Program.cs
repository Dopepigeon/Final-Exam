using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperaturClient
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

            controller.SetModel(model);

            FormMain mainForm = new FormMain(model, controller);
            Application.Run(mainForm);
        }
    }
}
