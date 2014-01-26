using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private Link(Node from, Node to)
        {
            from_ = from;
            to_ = to;
        }

        public void Draw(Graphics graphics)
        {
            Point a, b;
            try
            {
                a = from_.GetPosition();
                b = to_.GetPosition();
            }

            graphics.DrawLine(pen, a, b);
        }
    }
}
