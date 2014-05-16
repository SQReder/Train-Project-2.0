using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using TrainProject.Interfaces;

namespace TrainProject.Model
{
    public class Node : IDrawable, ISelectable, IPositionable, IEquatable<Node>
    {
        public enum DenominationValues
        {
            dv6, dv9, dv11, dv18, dv22
        }

        private const int Radius = 5;
        private PointF position_ = new Point(0,0);
        private readonly Brush highlightBrush_ = Brushes.DodgerBlue;
        private readonly Pen pen_ = new Pen(Color.SteelBlue,2f);
        private string title_;
        private DenominationValues? denominator_;

        public enum NodeType
        {
             Isolation
            ,Entrance
            ,Dock
            ,Ppp
            ,Cross
        }

        private NodeType type_ = NodeType.Isolation;

        public Node()
        {
            Selected = false;
        }

        public NodeType Type
        {
            get { return type_; }
            set { type_ = value; }
        }

        public string Title
        {
            get { return title_; }
            set { title_ = value; }
        }

        public DenominationValues? Denominator
        {
            get { return type_ == NodeType.Cross ? denominator_ : null; }
            set { denominator_ = value; }
        }

        #region IDrawable implementation

        public void Draw(Graphics graphics)
        {
            var position = Position;
            RectangleF rect;
            PointF[] lines;
            switch (type_)
            {
                case NodeType.Isolation:
                    rect = new RectangleF(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);

                    if (Selected)
                        graphics.FillRectangle(highlightBrush_, rect);
                    const float wideness = 0.7f;
                    graphics.DrawLine(pen_, new PointF(position.X - Radius * wideness, position.Y - Radius), new PointF(position.X + Radius * wideness, position.Y - Radius));
                    graphics.DrawLine(pen_, new PointF(position.X, position.Y - Radius), new PointF(position.X, position.Y + Radius));
                    graphics.DrawLine(pen_, new PointF(position.X - Radius * wideness, position.Y + Radius), new PointF(position.X + Radius * wideness, position.Y + Radius));
                    break;

                case NodeType.Entrance:
                    lines = new List<PointF>
                    {
                        new PointF(position.X - Radius / 2f, position.Y - Radius),
                        new PointF(position.X + Radius / 2f, position.Y),
                        new PointF(position.X - Radius / 2f, position.Y + Radius)
                    }.ToArray();
                    if (Selected)
                        graphics.FillPolygon(highlightBrush_, lines);
                    graphics.DrawLines(pen_, lines);
                    break;

                case NodeType.Dock:
                    if (Selected)
                    {
                        rect = new RectangleF(
                            position.X, position.Y - Radius,
                            Radius, Radius * 2 );
                        graphics.FillRectangle(highlightBrush_, rect);
                    }

                    lines = new List<PointF>
                    {
                        new PointF(position.X + Radius, position.Y + Radius),
                        new PointF(position.X, position.Y + Radius),
                        new PointF(position.X, position.Y),
                        new PointF(position.X, position.Y - Radius),
                        new PointF(position.X + Radius, position.Y - Radius)
                    }.ToArray();

                    graphics.DrawLines(pen_, lines);
                    break;

                case NodeType.Ppp:
                    if (Selected)
                    {
                        rect = new RectangleF(
                            position.X, position.Y - Radius,
                            Radius, Radius * 2);
                        graphics.FillRectangle(highlightBrush_, rect);
                    }

                    lines = new List<PointF>
                    {
                        new PointF(position.X + Radius, position.Y + Radius),
                        new PointF(position.X, position.Y + Radius),
                        new PointF(position.X, position.Y),
                        new PointF(position.X+Radius,position.Y),
                        new PointF(position.X, position.Y),
                        new PointF(position.X, position.Y - Radius),
                        new PointF(position.X + Radius, position.Y - Radius)
                    }.ToArray();

                    graphics.DrawLines(pen_, lines);

                    break;

                case NodeType.Cross:

                    if (Selected)
                    {
                        rect = new RectangleF(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);
                        graphics.FillRectangle(highlightBrush_, rect);
                    }
                    graphics.DrawLine(pen_, new PointF(position.X - Radius, position.Y), new PointF(position.X + Radius, position.Y));
                    graphics.DrawLine(pen_, new PointF(position.X - (int)(Radius * 0.5), position.Y), new PointF(position.X + (int)(Radius * 0.8), position.Y + (int)(Radius * 0.8)));
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            }; 
            
            var str = title_;
            if (type_ == NodeType.Cross)
            {
                str += ":" + (denominator_.HasValue ? denominator_.Value.ToString(CultureInfo.InvariantCulture).Substring(2) : "?");
            }

            var textPosition = new PointF(position.X, position.Y + Radius*4);
            graphics.DrawString(str, SystemFonts.DefaultFont, Brushes.Black, textPosition, stringFormat);
        }

        #endregion

        #region ISelectable implementation

        public bool Selected { get; private set; }

        public void UpdateSelectionState(Point position)
        {

            Selected = Vector.Distance(position_ ,position) < Radius + 4;
        }

        #endregion

        #region IEquatable impelementation

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return position_.Equals(other.position_) && string.Equals(title_, other.title_) && denominator_ == other.denominator_ && type_ == other.type_;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Node)) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = position_.GetHashCode();
                hashCode = (hashCode*397) ^ (title_ != null ? title_.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ denominator_.GetHashCode();
                hashCode = (hashCode*397) ^ (int) type_;
                return hashCode;
            }
        }

        #endregion

        #region IPositionable implementation

        public PointF Position
        {
            get { return position_; }
            set { position_ = value; }
        }

        #endregion
    }
}
