using SocketServer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class FormMain : Form
    {
        private IView iView;
        private IModel iModel;
        private IController iController;
        private AsyncSerialListener serialListener;

        public FormMain(IView iView, IModel iModel, IController iController)
        {
            this.iView = iView;
            this.iModel = iModel;
            this.iController = iController;

            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();

            foreach (var item in ports)
            {
                comboBoxPorts.Items.Add(item);
            }

            comboBoxPorts.SelectedIndex = 0;
        }

        private void buttonStartServer_Click(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = false;
            buttonStopServer.Enabled = true;
            iController.SetUpServer(IPAddress.Any, 11000);

            serialListener = new AsyncSerialListener(comboBoxPorts.SelectedItem.ToString(), iView);
            serialListener.StartSerial();
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = true;
            buttonStopServer.Enabled = false;
            iController.StopServer();

            if (serialListener != null)
            {
                serialListener.StopSerial();
            }
        }
    }
}
