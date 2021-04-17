using System;
using System.Drawing;

namespace SmDoorRandoTracker
{
    public enum ItemMode
    {
        UNCHECKED,
        CHECKED,
        HIGHLIGHTED
    }
    public class Item
    {
        public int X { get; set; }
        public int Y { get; set; }
        internal int Width { get; }
        internal int Height { get; }
        public ItemMode DisplayMode { get; set; }

        public Item(Point location) : this()
        {
            this.X = ((int)Math.Floor(location.X / 16f)) * 16;
            this.Y = ((int)Math.Floor(location.Y / 16f)) * 16;

        }
        public Item()
        {
            Width = 14;
            Height = 14;
            DisplayMode = ItemMode.UNCHECKED;

        }

        public bool Contains(Point p)
        {
            //    int dx = X - p.X;
            //    int dy = Y - p.Y;
            //    double dist = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            //    return dist < 8;
            return p.X >= X && p.X <= X + Width && p.Y >= Y && p.Y <= Y + Height;
        }

        internal void RotateCheck()
        {
            if (DisplayMode == ItemMode.HIGHLIGHTED)
            {
                DisplayMode = ItemMode.CHECKED;
            }
            else if (DisplayMode == ItemMode.CHECKED)
            {
                DisplayMode = ItemMode.UNCHECKED;
            }
            else if (DisplayMode == ItemMode.UNCHECKED)
            {
                DisplayMode = ItemMode.CHECKED;
            }
        }

        internal void RotateHighlight()
        {
            if (DisplayMode == ItemMode.HIGHLIGHTED)
            {
                DisplayMode = ItemMode.UNCHECKED;
            }
            else if (DisplayMode == ItemMode.UNCHECKED)
            {
                DisplayMode = ItemMode.HIGHLIGHTED;
            }
        }
    }
}