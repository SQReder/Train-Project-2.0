using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrainProject.JunctionEditor
{
    class Node : IDrawable, ISelectable, IPositionable
    {
        private const int Radius = 5;
        private Point position_ = new Point(0,0);
        private readonly Brush highlightBrush_ = Brushes.DodgerBlue;
        private readonly Pen pen_ = new Pen(Color.SteelBlue,2f);
        private bool isSelected_;
        private string title_;

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
            var position = GetPosition();
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
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            graphics.DrawString(title_, SystemFonts.DefaultFont, Brushes.Black, new Point(position.X - Radius, position.Y + Radius*2));
        }

        public Point GetPosition()
        {
            return position_;
        }

        public void SetPosition(Point position)
        {
            position_ = position;
        }

        public double Distance(Point position)
        {
            var pos = GetPosition();
            var a = Math.Pow(pos.X - position.X, 2);
            var b = Math.Pow(pos.Y - position.Y, 2);
            return Math.Sqrt(a + b);
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
    }
}
