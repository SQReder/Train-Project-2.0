using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using TrainProject.Vectors;

namespace TrainProject.JunctionEditor
{
    public class Link: IDrawable, IEquatable<Link>, ISelectable
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

        #region IDrawable implementation

        public void Draw(Graphics graphics)
        {
            try
            {
                var croppedLine = GetCroppedLine(LineMargin);
                var a = croppedLine.Item1;
                var b = croppedLine.Item2;

                graphics.DrawLine(Pen, a, b);

                if (Vector.Distance(from_,to_) > LineMargin*2)
                    DrawArrowHead(graphics, Pen);
                DrawLength(graphics);
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
            }
        }

        private void DrawArrowHead(Graphics g, Pen parentPen)
        {
            const float h = 10f;
            const float w = 4f;

            var croppedLine = GetCroppedLine(LineMargin);
            var croppedEnd = croppedLine.Item2;

            var mainVector = Vector.Create(from_, to_);
            var mainNormal = Vector.Normalize(mainVector);

            var cropVectorLen = Vector.Distance(from_.Position, croppedEnd);

            var oPointLen = cropVectorLen - h;
            var o = Vector.MultiplyByScalar(mainNormal, oPointLen);

            var normal = new PointF(-mainNormal.Y, mainNormal.X);

            var left = Vector.MultiplyByScalar(normal, w);
            var right = Vector.MultiplyByScalar(normal, -w);
            var sbase = Vector.Addition(from_.Position, o);

            var a = Vector.Addition(sbase, left);//new PointF(start.X + o.X + normal.X * w, start.Y + o.Y + normal.Y * w);
            var b = Vector.Addition(sbase, right);//new PointF(start.X + o.X + normal.X * -w, start.Y + o.Y + normal.Y * -w);

            var headPen = new Pen(parentPen.Color, parentPen.Width);
            g.DrawLine(headPen, croppedEnd, a);
            g.DrawLine(headPen, croppedEnd, b);
        }

        private void DrawLength(Graphics graphics)
        {
            var textMargin = SystemFonts.DefaultFont.Size * 1.5f;

            var mainVector = Vector.Create(from_.Position, to_.Position);

            var normal = Vector.Normalize(mainVector);
            var textNormal = Vector.Create(normal.Y, -normal.X); // turn normal 90 degree clockwise
            var textOffcet = Vector.MultiplyByScalar(textNormal, textMargin);

            var vectorLength = Vector.VectorLength(mainVector);
            var center = Vector.MultiplyByScalar(normal, vectorLength / 2f);
            
            var offset = Vector.Addition(center, textOffcet);

            var textPosition = Vector.Addition(From.Position, offset);

            var font = SystemFonts.DefaultFont;
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            length_ = (int)Math.Round(vectorLength);
            var label = length_.ToString(CultureInfo.InvariantCulture);

            graphics.DrawString(label, font, Brushes.Black, textPosition, stringFormat);
        }

        private Tuple<PointF, PointF> GetCroppedLine(float crops)
        {
            var start = from_.Position;
            var end = to_.Position;
            var mainVector = Vector.Create(from_.Position, to_.Position);
            var normal = Vector.Normalize(mainVector);

            var croppedVector = Vector.MultiplyByScalar(normal, crops);
            var a = Vector.Addition(start, croppedVector);
            var b = Vector.Divide(end, croppedVector);

            return new Tuple<PointF, PointF>(a, b);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Link other)
        {
            return from_.Equals(other.from_)
                   && to_.Equals(other.to_);
        }

        #endregion

        #region ISelectable implementation

        public bool IsSelected()
        {
            throw new NotImplementedException();
        }

        public void UpdateSelectionState(Point position)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
