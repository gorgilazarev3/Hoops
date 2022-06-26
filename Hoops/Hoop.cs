using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Hoops
{
    public class Hoop
    {
        //BACKBOARD
        //top left point of the backboard
        public Point BackboardStart { get; set; }
        //bottom right point of the backboard
        public Point BackboardEnd { get; set; }

        //RIM
        public Point RimLeftStart { get; set; }
        public Point RimLeftEnd { get; set; }
        public Point RimRightStart { get; set; }
        public Point RimRightEnd { get; set; }
        public Line InsideRim { get; set; }

        //HOOP POLE
        public Point PoleStart { get; set; }
        public Point PoleEnd { get; set; }

        public Hoop(Point backboardStart, Point backboardEnd, Point rimLeftStart, Point rimLeftEnd, Point rimRightStart, Point rimRightEnd, Point poleStart, Point poleEnd)
        {
            BackboardStart = backboardStart;
            BackboardEnd = backboardEnd;
            RimLeftStart = rimLeftStart;
            RimLeftEnd = rimLeftEnd;
            RimRightStart = rimRightStart;
            RimRightEnd = rimRightEnd;
            PoleStart = poleStart;
            PoleEnd = poleEnd;
            InsideRim = new Line();
            InsideRim.X1 = RimLeftEnd.X;
            InsideRim.Y1 = RimLeftEnd.Y;
            InsideRim.X2 = RimRightStart.X;
            InsideRim.Y2 = RimRightStart.Y;
        }
    }
}
