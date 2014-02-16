using System.Drawing;

namespace TrainProject.JunctionEditor
{
    interface IDrawable
    {
        /// <summary>
        /// Draw object on some graphics instance
        /// </summary>
        /// <param name="graphics">Graphics interface to draw on</param>
        void Draw(Graphics graphics);
    }
}