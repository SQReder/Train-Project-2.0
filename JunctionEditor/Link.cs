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
                var croppedLine = GetCroppedLine(from_, to_, 6);
                var a = croppedLine.Item1;
                var b = croppedLine.Item2;

                graphics.DrawLine(pen, a, b);
                DrawArrowHead(graphics, pen, from_, to_);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
            }
        }

        private void DrawArrowHead(Graphics g, Pen parentPen, Node nodeStart, Node nodeEnd)
        {
            const float h = 10f;
            const float w = 4f;

            var start = nodeStart.GetPosition();
            var end = nodeEnd.GetPosition();

            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = (float)nodeStart.Distance(end);
            var mainVectorNormal = new PointF(mainVector.X / mainVectorLen, mainVector.Y / mainVectorLen);

            var oPointLen = mainVectorLen - h;
            var o = new PointF(mainVectorNormal.X * oPointLen, mainVectorNormal.Y * oPointLen);

            var normal = new PointF(-mainVectorNormal.Y, mainVectorNormal.X);

            var A = new PointF(start.X + o.X + normal.X * w, start.Y + o.Y + normal.Y * w);
            var B = new PointF(start.X + o.X + normal.X * -w, start.Y + o.Y + normal.Y * -w);

            var headPen = new Pen(parentPen.Color, parentPen.Width);
            g.DrawLine(headPen, end, A);
            g.DrawLine(headPen, end, B);
        }

        private Tuple<PointF, PointF> GetCroppedLine(Node nodeStart, Node nodeEnd, float crops)
        {
            var start = nodeStart.GetPosition();
            var end = nodeEnd.GetPosition();
            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = (float)nodeStart.Distance(nodeEnd.GetPosition());
            var mainVectorNormal = new PointF(mainVector.X / mainVectorLen, mainVector.Y / mainVectorLen);

            var A = new PointF(start.X + mainVectorNormal.X * crops, start.Y + mainVectorNormal.Y * crops);
            var B = new PointF(end.X - mainVectorNormal.X * crops, end.Y - mainVectorNormal.Y * crops);

            return new Tuple<PointF, PointF>(A, B);
        }
    }
}
