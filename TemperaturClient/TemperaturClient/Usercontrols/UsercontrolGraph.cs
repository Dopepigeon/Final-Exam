using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TemperaturClient.FormMain;

namespace TemperaturClient.Usercontrols
{
    public partial class UsercontrolGraph : UserControl
    {
        List<PlottedPoint> res = new List<PlottedPoint>();
        private bool gotTarget = false;
        private PlottedPoint target;
        private PointF currentMousePos;
        private Font drawFont = new Font("Arial", 10);
        private SolidBrush drawBrush = new SolidBrush(Color.Black);
        private Pen greenPen = new Pen(Color.Green);

        public UsercontrolGraph()
        {
            InitializeComponent();
        }

        public void SetData(Bitmap bitmap, List<PlottedPoint> res)
        {
            this.res = res;
            pictureBoxGraph.Image = bitmap;
            pictureBoxGraph.Refresh();
        }

        private void pictureBoxGraph_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //order points based on distance
                target = res.OrderBy(item => Math.Abs(e.X - item.X)).First();
                currentMousePos = e.Location;

                //get distance between closestpoint and cursor
                double distance = GetDistance(target.X, target.Y, currentMousePos.X, currentMousePos.Y);

                if (distance < 20)
                {
                    gotTarget = true;
                }
                else
                {
                    gotTarget = false;
                }
            }
            catch (Exception) { }
            this.pictureBoxGraph.Invalidate();
        }

        private void pictureBoxGraph_Paint(object sender, PaintEventArgs e)
        {
            if (gotTarget)
            {
                //initial box offset is getting applied
                int offsetFromCursor = 5;
                int x = (int)currentMousePos.X + offsetFromCursor;
                int y = (int)currentMousePos.Y + offsetFromCursor;

                int xOffset = 0;
                int yOffset = 0;

                //edge check and offsetting to prevent drawing in void
                if (x + 202 > pictureBoxGraph.Width)
                {
                    xOffset = -215;
                }

                if (y + 47 > pictureBoxGraph.Height)
                {
                    yOffset = 60;
                }

                //drawing of the info box and its contents
                e.Graphics.FillEllipse(Brushes.Red, new RectangleF(target.X - 4, target.Y - 4, 8, 8));
                e.Graphics.FillRectangle(Brushes.DarkGray, new Rectangle(x + xOffset, y - yOffset, 202, 47));
                e.Graphics.DrawRectangle(greenPen, new Rectangle(x + xOffset, y - yOffset, 202, 47));
                e.Graphics.DrawString("Temperature: " + target.tempVal.temp.ToString() + " C°", drawFont, drawBrush, x + 5 + xOffset, y + 5 - yOffset);
                e.Graphics.DrawString("Timestamp: " + target.tempVal.dateTime.ToShortDateString() + " " + target.tempVal.dateTime.ToLongTimeString(), drawFont, drawBrush, x + 5 + xOffset, y + 25 - yOffset);
            }
        }

        private void pictureBoxGraph_MouseLeave(object sender, EventArgs e)
        {
            gotTarget = false;
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
