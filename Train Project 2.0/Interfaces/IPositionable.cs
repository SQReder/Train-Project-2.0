using System.Drawing;

namespace TrainProject.Interfaces
{
    /// <summary>
    /// Interface for something that have position
    /// </summary>
    public interface IPositionable
    {
        PointF Position { get; set; }
    }
}