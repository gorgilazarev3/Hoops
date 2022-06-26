using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class Court
    {
        public Hoop Hoop { get; set; }
        public Floor Floor { get; set; }

        public Court()
        {
        }

        public void InitializeHoop(Point backboardStart, Point backboardEnd, Point rimLeftStart, Point rimLeftEnd, Point rimRightStart, Point rimRightEnd, Point poleStart, Point poleEnd)
        {
            Hoop = new Hoop(backboardStart, backboardEnd, rimLeftStart, rimLeftEnd, rimRightStart, rimRightEnd, poleStart, poleEnd);
        }

        public void InitializeFloor(Point floorStart, Point floorEnd)
        {
            Floor = new Floor(floorStart, floorEnd);
        }

        public bool IsInitialized()
        {
            return Hoop != null && Floor != null;
        }
    }
}
