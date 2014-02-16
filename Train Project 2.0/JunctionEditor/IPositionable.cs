using System.Drawing;

namespace TrainProject.JunctionEditor
{
    /// <summary>
    /// Interface for something that have position
    /// </summary>
    public interface IPositionable
    {
        PointF Position { get; set; }
    }
}