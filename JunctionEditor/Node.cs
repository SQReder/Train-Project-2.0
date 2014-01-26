using System;
using System.Collections.Generic;
using System.Drawing;

namespace TrainProject.JunctionEditor
{
    class Node : IDrawable, ISelectable, IPositionable
    {
        private const int Radius = 4;
        private Point position_ = new Point(0,0);
        private Brush highlightBrush_ = Brushes.DodgerBlue;
        private readonly Pen pen_ = new Pen(Color.SteelBlue,2f);
        private bool isSelected_;
        private string title_;

        public enum NodeType
        {
            Isolation,
            Entrance,
            Dock,
            Ppp,
            Cross
        }

        private NodeType type_ = NodeType.Isolation;

        public void Draw(Graphics graphics)
        {
            var position = GetPosition();
            Rectangle rect;
            switch (type_)
            {
                case NodeType.Isolation:
                    rect = new Rectangle(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);

                    if (IsSelected())
                        graphics.FillEllipse(highlightBrush_, rect);
                    graphics.DrawEllipse(pen_, rect);
                    break;
                case NodeType.Entrance:
                    break;
                case NodeType.Dock:
                    if (isSelected_)
                    {
                        rect = new Rectangle(
                            position.X, position.Y - Radius,
                            Radius, Radius * 2 );
                        graphics.FillRectangle(highlightBrush_, rect);
                    }

                    var lines = new List<Point>();
                    lines.Add(new Point(position.X + Radius, position.Y + Radius));
                    lines.Add(new Point(position.X, position.Y + Radius));
                    lines.Add(new Point(position.X, position.Y));
                    lines.Add(new Point(position.X, position.Y - Radius));
                    lines.Add(new Point(position.X + Radius, position.Y - Radius));

                    graphics.DrawLines(pen_, lines.ToArray());
                    break;
                case NodeType.Ppp:
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
