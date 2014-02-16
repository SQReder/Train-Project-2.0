using System.Drawing;

namespace TrainProject.JunctionEditor
{
    /// <summary>
    /// Interface for something that have position
    /// </summary>
    public interface IPositionable
    {
        float X { get; }
        float Y { get; }
        PointF Position { get; set; }
        void MoveTo(PointF position);
    }
}