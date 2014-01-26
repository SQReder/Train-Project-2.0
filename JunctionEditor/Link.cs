using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    class Link: IDrawable
    {
        private Node from_, to_;
        static Pen pen = new Pen(Color.DarkViolet, 2f)
        {
            DashCap = DashCap.Round,
            DashPattern = new[] { 2.0F, 1.0F }
        };

        public Link(Node from, Node to)
        {
            from_ = from;
            to_ = to;
        }

        public Node From
        {
            get { return from_; }
        }

        public Node To
        {
            get { return to_; }
            set { to_ = value; }
        }

        public void Draw(Graphics graphics)
        {
            try
            {
                var a = from_.GetPosition();
                var b = to_.GetPosition();

                graphics.DrawLine(pen, a, b);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
            }
        }
    }
}
