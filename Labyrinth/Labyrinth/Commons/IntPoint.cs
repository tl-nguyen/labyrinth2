namespace Labyrinth.Commons
{
    /// <summary>
    /// Provides a point with X and Y coordinates
    /// </summary>
    public class IntPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntPoint" /> class
        /// </summary>
        /// <param name="x">sets the X property to any integer number</param>
        /// <param name="y">sets the Y property to any integer number</param>
        public IntPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the X value
        /// </summary>
        public int Y { get; set; }
    }
}