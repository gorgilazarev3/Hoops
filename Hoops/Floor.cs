using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class Floor
    {
        public Point FloorStart { get; set; }
        public Point FloorEnd { get; set; }

        public Floor(Point floorStart, Point floorEnd)
        {
            FloorStart = floorStart;
            FloorEnd = floorEnd;
        }
    }
}
