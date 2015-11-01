using System.Runtime.InteropServices;

namespace Attribute.Hooks.Windows.Interop.NativeMethods
{
    /// <summary>
    ///     Defines the X- and Y-coordinates of a point.  Supports unmanaged data mapping.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        private int _xPos;
        private int _yPos;

        public Point(int x, int y)
            : this()
        {
            this.X = x;
            this.Y = y;
        }


        #region [ -- PROPERTIES -- ]

        /// <summary>
        ///     The x-coordinate of the point.
        /// </summary>
        public int X
        {
            get { return this._xPos; }
            set { this._xPos = value; }
        }

        /// <summary>
        ///     The y-coordinate of the point.
        /// </summary>
        public int Y
        {
            get { return this._yPos; }
            set { this._yPos = value; }
        }

        #endregion


        #region [ -- PUBLIC & PROTECTED METHODS -- ]

        /// <summary>
        ///     The string representation of the point. Represented as "{<see cref="X" />, <see cref="Y" />}".
        /// </summary>
        /// <returns>The string representation of the point.</returns>
        public override string ToString()
        {
            return $"{{{this._xPos}, {this._yPos}}}";
        }

        /// <summary>
        ///     Converts a <see cref="Point" /> <see cref="point" /> into a managed <see cref="System.Drawing.Point" />.
        /// </summary>
        /// <param name="point">The <see cref="Point" /> to convert.</param>
        /// <returns>
        ///     A new <see cref="System.Drawing.Point" /> with the same coordinates as the original <see cref="Point" />
        /// </returns>
        public static explicit operator System.Drawing.Point(Point point)
        {
            return new System.Drawing.Point(point.X, point.Y);
        }

        public static explicit operator Point(System.Drawing.Point point)
        {
            return new Point
                   {
                       X = point.X,
                       Y = point.Y
                   };
        }

        #endregion
    }
}
