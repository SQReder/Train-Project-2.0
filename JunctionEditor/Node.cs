using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace TrainProject.JunctionEditor
{
    public class Node : IDrawable, ISelectable, IPositionable, IEquatable<Node>
    {
        private const int Radius = 5;
        private Point position_ = new Point(0,0);
        private readonly Brush highlightBrush_ = Brushes.DodgerBlue;
        private readonly Pen pen_ = new Pen(Color.SteelBlue,2f);
        private bool isSelected_;
        private string title_;
        private int denominator_;

        public enum NodeType
        {
             Isolation
            ,Entrance
            ,Dock
            ,Ppp
            ,Cross
        }

        private NodeType type_ = NodeType.Isolation;

        public void Draw(Graphics graphics)
        {
            var position = Position;
            Rectangle rect;
            Point[] lines;
            switch (type_)
            {
                case NodeType.Isolation:
                    rect = new Rectangle(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);

                    if (IsSelected())
                        graphics.FillRectangle(highlightBrush_, rect);
                    graphics.DrawLine(pen_, new Point(position.X - Radius, position.Y - Radius), new Point(position.X + Radius, position.Y - Radius));
                    graphics.DrawLine(pen_, new Point(position.X, position.Y - Radius), new Point(position.X, position.Y + Radius));
                    graphics.DrawLine(pen_, new Point(position.X - Radius, position.Y + Radius), new Point(position.X + Radius, position.Y + Radius));
                    break;

                case NodeType.Entrance:
                    lines = new List<Point>
                    {
                        new Point(position.X - Radius / 2, position.Y - Radius),
                        new Point(position.X + Radius / 2, position.Y),
                        new Point(position.X - Radius / 2, position.Y + Radius)
                    }.ToArray();
                    if (IsSelected())
                        graphics.FillPolygon(highlightBrush_, lines);
                    graphics.DrawLines(pen_, lines);
                    break;

                case NodeType.Dock:
                    if (isSelected_)
                    {
                        rect = new Rectangle(
                            position.X, position.Y - Radius,
                            Radius, Radius * 2 );
                        graphics.FillRectangle(highlightBrush_, rect);
                    }

                    lines = new List<Point>
                    {
                        new Point(position.X + Radius, position.Y + Radius),
                        new Point(position.X, position.Y + Radius),
                        new Point(position.X, position.Y),
                        new Point(position.X, position.Y - Radius),
                        new Point(position.X + Radius, position.Y - Radius)
                    }.ToArray();

                    graphics.DrawLines(pen_, lines);
                    break;

                case NodeType.Ppp:
                    if (isSelected_)
                    {
                        rect = new Rectangle(
                            position.X, position.Y - Radius,
                            Radius, Radius * 2);
                        graphics.FillRectangle(highlightBrush_, rect);
                    }

                    lines = new List<Point>
                    {
                        new Point(position.X + Radius, position.Y + Radius),
                        new Point(position.X, position.Y + Radius),
                        new Point(position.X, position.Y),
                        new Point(position.X+Radius,position.Y),
                        new Point(position.X, position.Y),
                        new Point(position.X, position.Y - Radius),
                        new Point(position.X + Radius, position.Y - Radius)
                    }.ToArray();

                    graphics.DrawLines(pen_, lines);

                    break;

                case NodeType.Cross:

                    if (IsSelected())
                    {
                        rect = new Rectangle(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);
                        graphics.FillRectangle(highlightBrush_, rect);
                    }
                    graphics.DrawLine(pen_, new Point(position.X - Radius, position.Y), new Point(position.X + Radius, position.Y));
                    graphics.DrawLine(pen_, new Point(position.X - (int)(Radius * 0.5), position.Y), new Point(position.X + (int)(Radius * 0.8), position.Y + (int)(Radius * 0.8)));
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
                str += ":" + denominator_.ToString(CultureInfo.InvariantCulture);

            var textPosition = new Point(position.X, position.Y + Radius*3);
            graphics.DrawString(str, SystemFonts.DefaultFont, Brushes.Black, textPosition, stringFormat);
        }

        public Point Position
        {
            get { return position_; }
            set { position_ = value; }
        }

        public float Distance(Point position)
        {
            var pos = Position;
            var a = Math.Pow(pos.X - position.X, 2);
            var b = Math.Pow(pos.Y - position.Y, 2);
            return (float)Math.Sqrt(a + b);
        }

        public bool IsSelected()
        {
            return isSelected_;
        }

        public void UpdateSelectionState(Point position)
        {

            isSelected_ = Distance(position) < Radius + 4;
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

        public int Denominator
        {
            get { return denominator_; }
            set { denominator_ = value; }
        }

        public bool Equals(Node other)
        {
            return position_ == other.position_
                   && type_ == other.type_
                   && denominator_ == other.denominator_
                   && title_ == other.title_;
        }
    }
}
