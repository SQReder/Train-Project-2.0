using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace TrainProject.JunctionEditor
{
    public class Link: IDrawable, IEquatable<Link>
    {
        private const float LineMargin = 8f;
        private readonly Node from_;
        private Node to_;
        private int length_ = 0;

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

        //public int Length
        //{
        //    get { return length_; }
        //}

        public void Draw(Graphics graphics)
        {
            try
            {
                var croppedLine = GetCroppedLine(from_, to_, LineMargin);
                var a = croppedLine.Item1;
                var b = croppedLine.Item2;

                graphics.DrawLine(Pen, a, b);

                if (from_.Distance(to_.Position) > LineMargin*2)
                    DrawArrowHead(graphics, Pen, from_, to_);
                DrawLength(graphics);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
            }
        }

        private static void DrawArrowHead(Graphics g, Pen parentPen, IPositionable nodeStart, IPositionable nodeEnd)
        {
            const float h = 10f;
            const float w = 4f;

            var croppedLine = GetCroppedLine(nodeStart, nodeEnd, LineMargin);
            var start = nodeStart.Position;
            var end = croppedLine.Item2;

            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = nodeStart.Distance(new Point((int)end.X,(int)end.Y));
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

        private void DrawLength(Graphics graphics)
        {
            var distance = from_.Distance(to_.Position);
            length_ = (int) Math.Round(distance);
            var label = length_.ToString(CultureInfo.InvariantCulture);

            var mainVector = new Point(To.Position.X - From.Position.X, To.Position.Y - From.Position.Y);
            
            var normal = new SizeF(mainVector.X / distance, mainVector.Y / distance);
            var textNormal = new SizeF(normal.Height, -normal.Width); // turn normal 90 degree clockwise

            var center = new SizeF(normal.Width * distance / 2f, normal.Height * distance / 2f);
            var textMargin = SystemFonts.DefaultFont.Size * 1.5f;
            var textOffcet = new SizeF(textNormal.Width*textMargin, textNormal.Height*textMargin);
            var offset = center + textOffcet;
            var intOffset = new Size((int) offset.Width, (int) offset.Height);

            var textPosition = From.Position + intOffset;

            var font = SystemFonts.DefaultFont;
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            graphics.DrawString(label, font, Brushes.Black, textPosition, stringFormat);
        }

        private static Tuple<PointF, PointF> GetCroppedLine(IPositionable nodeStart, IPositionable nodeEnd, float crops)
        {
            var start = nodeStart.Position;
            var end = nodeEnd.Position;
            var mainVector = new PointF(end.X - start.X, end.Y - start.Y);
            var mainVectorLen = nodeStart.Distance(nodeEnd.Position);
            var mainVectorNormal = new PointF(mainVector.X / mainVectorLen, mainVector.Y / mainVectorLen);

            var a = new PointF(start.X + mainVectorNormal.X * crops, start.Y + mainVectorNormal.Y * crops);
            var b = new PointF(end.X - mainVectorNormal.X * crops, end.Y - mainVectorNormal.Y * crops);

            return new Tuple<PointF, PointF>(a, b);
        }


        public bool Equals(Link other)
        {
            return from_.Equals(other.from_)
                   && to_.Equals(other.to_);
        }
    }
}
