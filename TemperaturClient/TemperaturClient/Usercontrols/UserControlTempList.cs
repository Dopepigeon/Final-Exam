using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperaturClient.Usercontrols
{
    public partial class UserControlTempList : UserControl
    {
        List<Temperatur> dataToPlot = new List<Temperatur>();

        public UserControlTempList()
        {
            InitializeComponent();
        }
    
        public void SetData(List<Temperatur> dataToPlot)
        {
            this.dataToPlot = dataToPlot;

            foreach (var item in dataToPlot)
            {
                listBoxData.Items.Add($"{item.temp} C° --> {item.dateTime.ToShortDateString()} { item.dateTime.ToLongTimeString()}");
            }
        }
    }
}
