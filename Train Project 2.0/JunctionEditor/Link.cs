using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using TrainProject.Vectors;

namespace TrainProject.JunctionEditor
{
    public class Link: IDrawable, IEquatable<Link>, ISelectable
    {
        private const float LineMargin = 8f;
        private Node from_;
        private Node to_;
        private int length_ = 0;
        private bool fixedLength_;

        static readonly Pen Pen = new Pen(Color.DarkViolet, 2f)
        {
            DashCap = DashCap.Round,
            DashPattern = new[] { 2.0F, 1.0F }
        };

        static readonly Pen PenHighlight = new Pen(Color.Violet, 2f)
        {
            DashCap = DashCap.Round,
            DashPattern = new[] { 2.0F, 1.0F }
        };

        public int Length
        {
            get
            {
                if (!fixedLength_)
                {
                    var mainVector = new Vector(from_.Position, to_.Position);
                    length_ = (int)Math.Round(mainVector.Length);
                }
                
                return length_;
            }
            set {
                if (value != 0)
                {
                    fixedLength_ = true;
                    length_ = value;
                }
                else
                {
                    length_ = value;
                }
            }
        }

        public Link(Node from, Node to)
        {
            Selected = false;
            from_ = from;
            to_ = to;
        }

        public Link()
        { }

        public Node From
        {
            get { return from_; }
            set
            {
                if (ReferenceEquals(value, null))
                    throw new NullReferenceException();

                from_ = value;
            }
        }

        public Node To
        {
            get { return to_; }
            set
            {
                if (ReferenceEquals(value, null))
                    throw new NullReferenceException();
                to_ = value;
            }
        }

        #region IDrawable implementation

        public void Draw(Graphics graphics)
        {
            try
            {
                var croppedLine = GetCroppedLine(LineMargin);
                var a = croppedLine.First;
                var b = croppedLine.Second;

                var pen = Selected ? PenHighlight : Pen;
                graphics.DrawLine(pen, a, b);

                if (Vector.Distance(from_,to_) > LineMargin*2)
                    DrawArrowHead(graphics, pen);
                DrawLength(graphics);
            }
            catch (Exception e)
            {
                // ReSharper disable LocalizableElement
                MessageBox.Show("Can't draw link between nodes! Reason: \"" + e.Message + "\"\nContact with developer.");
                // ReSharper restore LocalizableElement
            }
        }

        private void DrawArrowHead(Graphics g, Pen parentPen)
        {
            const float h = 10f;
            const float w = 4f;

            var croppedLine = GetCroppedLine(LineMargin);
            var croppedEnd = croppedLine.Second;

            var mainVector = new Vector(from_, to_);
            var mainNormal = mainVector.Normalized;

            var cropVectorLen = Vector.Distance(from_.Position, croppedEnd);

            var oPointLen = cropVectorLen - h;
            var o = mainNormal.Multiplied(oPointLen); //Vector.MultiplyByScalar(mainNormal, oPointLen);

            var normal = new Vector(-mainNormal.Y, mainNormal.X);

            var left = normal.Multiplied(w);
            var right = normal.Multiplied(-w);
            var sbase = from_.Position + (SizeF)o;

            var a = sbase + (SizeF)left;//new PointF(start.X + o.X + normal.X * w, start.Y + o.Y + normal.Y * w);
            var b = sbase + (SizeF)right;//new PointF(start.X + o.X + normal.X * -w, start.Y + o.Y + normal.Y * -w);

            var headPen = new Pen(parentPen.Color, parentPen.Width);
            g.DrawLine(headPen, croppedEnd, a);
            g.DrawLine(headPen, croppedEnd, b);
        }

        private void DrawLength(Graphics graphics)
        {
            var textMargin = SystemFonts.DefaultFont.Size * 1.5f;

            var mainVector = new Vector(from_.Position, to_.Position);

            var normal = mainVector.Normalized;
            var textNormal = new Vector(normal.Y, -normal.X); // turn normal 90 degree clockwise
            var textOffcet = textNormal.Multiplied(textMargin);

            var vectorLength = mainVector.Length;
            var center = normal.Multiplied(vectorLength / 2f);
            
            var offset = center.Add(textOffcet);

            var textPosition = From.Position + (SizeF)offset;

            var font = SystemFonts.DefaultFont;
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var length = fixedLength_ ? Length : (int)Math.Round(vectorLength);
            var label = length.ToString(CultureInfo.InvariantCulture);

            graphics.DrawString(label, font, Brushes.Black, textPosition, stringFormat);
        }

        private Pair<PointF> GetCroppedLine(float crops)
        {
            var start = (Vector)from_.Position;
            var end = (Vector)to_.Position;
            var mainVector = new Vector(from_.Position, to_.Position);
            var normal = mainVector.Normalized;

            var croppedVector = normal.Multiplied(crops);
            var a = (PointF)start.Add(croppedVector);
            var b = (PointF)end.Substract(croppedVector);

            return new Pair<PointF>(a, b);
        }

        #endregion

        #region IEquatable implementation

        public bool Equals(Link other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(from_, other.from_) && Equals(to_, other.to_) && Equals(length_, other.length_);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Link)) return false;
            return Equals((Link) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((from_ != null ? from_.GetHashCode() : 0)*397) ^ (to_ != null ? to_.GetHashCode() : 0);
            }
        }

        #endregion

        #region ISelectable implementation

        public bool Selected { get; private set; }

        public void UpdateSelectionState(Point position)
        {
            var start = from_.Position;
            var end = to_.Position;

            var linkLength = Vector.Distance(start, end);
            var pointSidesLength = Vector.Distance(start, position) + Vector.Distance(position, end);

            Selected = pointSidesLength - linkLength < 0.5;
        }

        #endregion

        public PointF MapPointToLine(PointF point)
        {
            return Vector.MapPointToVector(From.Position, To.Position, point);
        }
    }
}
