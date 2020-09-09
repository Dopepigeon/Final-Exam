using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using TemperaturClient.Usercontrols;

namespace TemperaturClient
{
    public partial class FormMain : Form
    {
        public struct PlottedPoint
        {
            public Temperatur tempVal;
            public float X;
            public float Y;

            public PlottedPoint(Temperatur tempVal, float X, float Y)
            {
                this.tempVal = tempVal;
                this.X = X;
                this.Y = Y;
            }
        }

        List<PlottedPoint> res = new List<PlottedPoint>();
        List<Temperatur> dataToPlot = new List<Temperatur>();

        private Pen bluePen = new Pen(Color.Blue);

        private IModel iModel;
        private IController iController;

        public FormMain(IModel model, IController controller)
        {
            this.iModel = model;
            this.iController = controller;

            InitializeComponent();
        }

        private void buttonShowData_Click(object sender, EventArgs e)
        {
            DateTime dtStart = dateTimePickerStart.Value;
            dtStart = dtStart.Date + dateTimePickerStartTime.Value.TimeOfDay;

            DateTime dtEnd = dateTimePickerEnd.Value;
            dtEnd = dtEnd.Date + dateTimePickerEndTime.Value.TimeOfDay;

            dataToPlot = iController.GetDataFromServer(dtStart, dtEnd);

            
            if (dataToPlot.Count != 0)
            {
                res = GeneratePlot(dataToPlot, dtStart, dtEnd, usercontrolGraph.pictureBoxGraph.Height, usercontrolGraph.pictureBoxGraph.Width);

                Bitmap bitmap = new Bitmap(usercontrolGraph.pictureBoxGraph.Width, usercontrolGraph.pictureBoxGraph.Height);

                List<PointF> points = new List<PointF>();

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    foreach (var tempVal in res)
                    {
                        //render point
                        graphics.FillEllipse(Brushes.Blue, new RectangleF(tempVal.X - 5, tempVal.Y - 5, 10, 10));
                        points.Add(new PointF(tempVal.X, tempVal.Y));
                    }

                    //connect points with continous line
                    graphics.DrawCurve(bluePen, points.ToArray(), 0.1f);
                }

                usercontrolGraph.SetData(bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare), res);
                userControlTempList.SetData(dataToPlot);

                if (radioButtonGraph.Checked)
                {
                    usercontrolGraph.Visible = true;
                }
                else
                {
                    userControlTempList.Visible = true;
                }

                bitmap.Dispose();
            }
            else
            {
                MessageBox.Show("The Server did not return any data for this timespan!");
            }
        }

        public List<PlottedPoint> GeneratePlot(List<Temperatur> series, DateTime start, DateTime end, int height, int width)
        {
            List<PlottedPoint> generatedCoordinates = new List<PlottedPoint>();

            //get max and min temp for y axis scaling
            float tempMax = (float)series.Max(e => e.temp);
            float tempMin = (float)series.Min(e => e.temp);

            //get max and min unixtimestamp for x axis scaling
            long maxUnix = ((DateTimeOffset)series.Max(e => e.dateTime)).ToUnixTimeSeconds();
            long minUnix = ((DateTimeOffset)series.Min(e => e.dateTime)).ToUnixTimeSeconds();

            foreach (var item in series)
            {
                //map temps and dates into different range (picbox size)
                double x = Map(((DateTimeOffset)item.dateTime).ToUnixTimeSeconds(), (long)minUnix, (long)maxUnix, 0, (long)width);
                double y = MapFloatRange((double)item.temp, (double)tempMin, (double)tempMax, (double)height - 10, 10, 5);
                generatedCoordinates.Add(new PlottedPoint(item, (float)x, (float)y));
            }

            return generatedCoordinates;
        }

        public long Map(long x, long in_min, long in_max, long out_min, long out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        public static double MapFloatRange(double sourceNumber, double fromA, double fromB, double toA, double toB, int decimalPrecision)
        {
            double deltaA = fromB - fromA;
            double deltaB = toB - toA;
            double scale = deltaB / deltaA;
            double negA = -1 * fromA;
            double offset = (negA * scale) + toA;
            double finalNumber = (sourceNumber * scale) + offset;
            int calcScale = (int)Math.Pow(10, decimalPrecision);
            return (double)Math.Round(finalNumber * calcScale) / calcScale;
        }

        private void radioButtonList_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonList.Checked)
            {
                userControlTempList.Visible = true;
                usercontrolGraph.Visible = false;
            }
            else
            {
                userControlTempList.Visible = false;
                usercontrolGraph.Visible = true;
            }
        }

        private void radioButtonGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGraph.Checked)
            {
                userControlTempList.Visible = false;
                usercontrolGraph.Visible = true;
            }
            else
            {
                userControlTempList.Visible = true;
                usercontrolGraph.Visible = false;
            }
        }
    }
}
