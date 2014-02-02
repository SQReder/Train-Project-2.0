using System.Drawing;

namespace TrainProject.JunctionEditor
{
    /// <summary>
    /// Interface for something that have position
    /// </summary>
    interface IPositionable
    {
        /// <summary>
        /// Calculate distance from object position to some other coordinate
        /// </summary>
        /// <param name="position">Coordinate to calculate distance between</param>
        /// <returns>Distance between object position and coordinate from argument</returns>
        float Distance(Point position);

        Point Position { get; set; }
    }
}