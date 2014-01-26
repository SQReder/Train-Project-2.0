using System.Drawing;

namespace TrainProject.JunctionEditor
{
    /// <summary>
    /// Interface for selectable objects
    /// </summary>
    interface ISelectable
    {
        /// <summary>
        /// Return current selection state
        /// </summary>
        /// <returns>True if object selected otherwise false</returns>
        bool IsSelected();

        /// <summary>
        /// Update current selected state
        /// </summary>
        /// <param name="position">TODO </param>
        void UpdateSelectionState(Point position);
    }
}