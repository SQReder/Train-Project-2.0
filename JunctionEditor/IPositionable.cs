using System.Drawing;

namespace TrainProject.JunctionEditor
{
    /// <summary>
    /// Interface for something that have position
    /// </summary>
    interface IPositionable
    {
        /// <summary>
        /// Get the object position
        /// </summary>
        /// <returns>Point that reperesent current object position</returns>
        Point GetPosition();

        /// <summary>
        /// Set object position
        /// </summary>
        /// <param name="position">New position for object</param>
        void SetPosition(Point position);

        /// <summary>
        /// Calculate distance from object position to some other coordinate
        /// </summary>
        /// <param name="position">Coordinate to calculate distance between</param>
        /// <returns>Distance between object position and coordinate from argument</returns>
        double Distance(Point position);
    }
}