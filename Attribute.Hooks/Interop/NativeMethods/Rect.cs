using System.Drawing;
using System.Runtime.InteropServices;

namespace Attribute.Hooks.Windows.Interop.NativeMethods
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        private int _left;
        private int _top;
        private int _right;
        private int _bottom;

        public Rect(int x, int y, int width, int height)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public static explicit operator Rectangle(Rect rect)
        {
            return new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        public static explicit operator Rect(Rectangle rectangle)
        {
            return new Rect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public int X
        {
            get { return this._left; }
            set
            {
                this._right -= this._left - value;
                this._left = value;
            }
        }

        public int Y
        {
            get { return this._top; }
            set
            {
                this._bottom -= this._top - value;
                this._top = value;
            }
        }

        public int Width
        {
            get { return this._right - this._left; }
            set { this._right = value + this._left; }
        }

        public int Height
        {
            get { return this._bottom - this._top; }
            set { this._bottom = value + this._top; }
        }
    }
}
