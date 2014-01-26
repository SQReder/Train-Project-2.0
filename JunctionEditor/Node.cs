using System;
using System.Drawing;

namespace TrainProject.JunctionEditor
{
    class Node : IDrawable, ISelectable, IPositionable
    {
        private const int Radius = 4;
        private Point position_ = new Point(0,0);
        private Brush highlightBrush_ = Brushes.DodgerBlue;
        private readonly Pen pen_ = Pens.SteelBlue;
        private bool isSelected_;

        public void Draw(Graphics graphics)
        {
            var size = new Size(Radius * 2, Radius * 2);
            var rect = new Rectangle(GetPosition(), size);

            if (IsSelected())
                graphics.FillEllipse(highlightBrush_, rect);
            graphics.DrawEllipse(pen_, rect);
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
    }
}
