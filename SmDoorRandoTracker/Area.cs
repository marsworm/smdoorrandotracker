using System.Collections.Generic;

namespace SmDoorRandoTracker
{
    public class Area
    {
        public string Name { get; set; }
        public List<Rect> Rect { get; set; }
        public List<Item> Items { get; set; }
        public List<Door> Doors { get; set; }

    }
}