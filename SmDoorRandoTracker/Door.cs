using System;
using System.Drawing;

namespace SmDoorRandoTracker
{
    public class Door
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int H { get; set; }
        public int W { get; set; }
        public int Color { get; set; }
        public bool Opened { get; set; }
        internal SolidBrush solidBrush;

        public Door()
        {
            W = 6;
            H = 14;
        }
        public Door(Point location, Color color) : this()
        {
            this.X = ((int)Math.Round(location.X / 16f)) * 16;
            this.Y = ((int)Math.Floor(location.Y / 16f)) * 16;
            X -= (W / 2);
            solidBrush = new SolidBrush(color);
            Color = color.ToArgb();
        }


        public bool Contains(int pX, int pY)
        {
            return pX >= X && pX <= X + W && pY >= Y && pY <= Y + H;
        }
    }
}