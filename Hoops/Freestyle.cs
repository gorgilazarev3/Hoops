using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class Freestyle
    {
        public Hoop Hoop { get; set; }
        public Floor Floor { get; set; }
        public double Power { get; set; }
        public int Angle { get; set; }
        public static int GRAVITY { get; set; } = 5;
        public Basketball Basketball { get; set; }
        public bool IsStarted { get; set; }
        public bool PowerSet { get; set; }

        public Freestyle(Point rimLocation)
        {
            Power = 20;
            Angle = 35;
            Basketball = null;
            IsStarted = false;
            Hoop = new Hoop(new Point(688, 3), new Point(688, 89), new Point(rimLocation.X - 37, rimLocation.Y), new Point(rimLocation.X - 21, rimLocation.Y), new Point(rimLocation.X + 23, rimLocation.Y), new Point(rimLocation.X + 40, rimLocation.Y), new Point(710, 95), new Point(710, 340));
            //Hoop = new Hoop(new Point(688, 3), new Point(688, 89), new Point(rimLocation.X - 37, rimLocation.Y), new Point(rimLocation.X - 21, rimLocation.Y), new Point(rimLocation.X + 23, rimLocation.Y), new Point(rimLocation.X + 40, rimLocation.Y), new Point(710, 95), new Point(710, 340));
            Floor = new Floor(new Point(69, 550), new Point(742, 346));
            PowerSet = false;
        }

        public void StartGame(Point initialBallLocation, int radius)
        {
            if(Basketball == null)
            {
                Basketball = new Basketball(initialBallLocation, radius);
                IsStarted = true;
            }
        }

        public void Shoot()
        {
            Basketball.SecondsSinceShot++;
            //Basketball.Shoot(Power, Angle, GRAVITY, Court);
            if (!Basketball.IsShot)
            {
                IsStarted = false;
                PowerSet = false;
            }
        }

        public void SetPower(int newPower)
        {
            Power = newPower;
        }

        public void DrawCurveFromBall(Graphics g)
        {
            Basketball.DrawCurveFromBall(g, Angle);
        }

    }
}
