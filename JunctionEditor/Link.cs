using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    class Link: IDrawable
    {
        private const float LineMargin = 8f;
        private readonly Node from_;
        private Node to_;

        static readonly Pen Pen = new Pen(Color.DarkViolet, 2f)
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
                var croppedLine = GetCroppedLine(from_, to_, LineMargin);
                var a = croppedLine.Item1;
                var b = croppedLine.Item2;

                graphics.DrawLine(Pen, a, b);

                if (from_.Distance(to_.GetPosition()) > LineMargin*2)
                    DrawArrowHead(graphics, Pen, from_, to_);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
            }
        }

        private void DrawArrowHead(Graphics g, Pen parentPen, IPositionable nodeStart, IPositionable nodeEnd)
        {
            const float h = 10f;
            const float w = 4f;

            var croppedLine = GetCroppedLine(nodeStart, nodeEnd, LineMargin);
            var start = nodeStart.GetPosition();
            var end = croppedLine.Item2;

            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = (float)nodeStart.Distance(new Point((int)end.X,(int)end.Y));
            var mainVectorNormal = new PointF(mainVector.X / mainVectorLen, mainVector.Y / mainVectorLen);

            var oPointLen = mainVectorLen - h;
            var o = new PointF(mainVectorNormal.X * oPointLen, mainVectorNormal.Y * oPointLen);

            var normal = new PointF(-mainVectorNormal.Y, mainVectorNormal.X);

            var a = new PointF(start.X + o.X + normal.X * w, start.Y + o.Y + normal.Y * w);
            var b = new PointF(start.X + o.X + normal.X * -w, start.Y + o.Y + normal.Y * -w);

            var headPen = new Pen(parentPen.Color, parentPen.Width);
            g.DrawLine(headPen, end, a);
            g.DrawLine(headPen, end, b);
        }

        private static Tuple<PointF, PointF> GetCroppedLine(IPositionable nodeStart, IPositionable nodeEnd, float crops)
        {
            var start = nodeStart.GetPosition();
            var end = nodeEnd.GetPosition();
            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = (float)nodeStart.Distance(nodeEnd.GetPosition());
            var mainVectorNormal = new PointF(mainVector.X / mainVectorLen, mainVector.Y / mainVectorLen);

            var a = new PointF(start.X + mainVectorNormal.X * crops, start.Y + mainVectorNormal.Y * crops);
            var b = new PointF(end.X - mainVectorNormal.X * crops, end.Y - mainVectorNormal.Y * crops);

            return new Tuple<PointF, PointF>(a, b);
        }
    }
}
