using System;
using System.Collections.Generic;
using System.Drawing;

namespace SmDoorRandoTracker
{
    public class MapInfo
    {
        public List<Area> Areas { get; set; }

        internal void Init()
        {
            foreach (Area a in Areas)
            {
                a.Doors.ForEach(d => d.solidBrush = new SolidBrush(Color.FromArgb(d.Color)));
                a.Items.ForEach(d =>
                {
                    d.X = ((int)Math.Floor(d.X / 16f)) * 16;
                    d.Y = ((int)Math.Floor(d.Y / 16f)) * 16;
                    //d.X += 8;
                    //d.Y -= 8;
                });
            }
        }
    }
}