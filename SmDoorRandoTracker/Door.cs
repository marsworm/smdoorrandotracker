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
        public bool Horizontal { get; set; }
        public int[] Connect { get; set; }

        internal SolidBrush solidBrush;

        public Door()
        {
            //Horizontal = false;
        }
        public Door(Point location, Color color, bool horizontal)// : this()
        {
            this.X = ((int)Math.Round(location.X / 16f)) * 16;
            this.Y = ((int)Math.Floor(location.Y / 16f)) * 16;
            if (horizontal)
            {
                H = 6;
                W = 14;
                Y -= (H / 2);
            }
            else
            {
                W = 6;
                H = 14;
                X -= (W / 2);
            }
            this.Horizontal = horizontal;

            SetColor(color);
        }

        public void SetColor(Color color)
        {

            solidBrush = new SolidBrush(color);
            Color = color.ToArgb();
        }

        public bool Contains(int pX, int pY)
        {
            return pX >= X && pX <= X + W && pY >= Y && pY <= Y + H;
        }
    }
}