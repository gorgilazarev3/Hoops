using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Hoops
{
    public class Basketball
    {
        public Point InitialLocation { get; set; }
        public Point CurrentLocation { get; set; }
        public bool IsShot { get; set; }
        public bool IsInHoop { get; set; }
        public bool IsBouncing { get; set; }
        public int SecondsSinceShot { get; set; }
        public double BounceCoef { get; set; }
        public double Power { get; set; }
        public int Radius { get; set; }
        private int RotationAngle { get; set; }

        public Basketball(Point initialLocation, int radius)
        {
            InitialLocation = initialLocation;
            CurrentLocation = InitialLocation;
            IsShot = false;
            IsInHoop = false;
            IsBouncing = false;
            SecondsSinceShot = 0;
            BounceCoef = 1;
            Power = 50;
            Radius = radius;
            RotationAngle = 0;
        }

        public void ShootTimed(int barValue, Court court)
        {
            IsShot = true;
            int nextY = CurrentLocation.Y - 1;
            if(nextY <= court.Hoop.BackboardStart.Y && CurrentLocation.X >= court.Hoop.BackboardStart.X && CurrentLocation.X <= court.Hoop.BackboardEnd.X)
            {
                IsBouncing = true;
            }
            if (IsBouncing)
                nextY = CurrentLocation.Y + 1;
            
            if(CurrentLocation.X >= court.Hoop.InsideRim.X1 && CurrentLocation.X <= court.Hoop.InsideRim.X2 && CurrentLocation.Y >= court.Hoop.InsideRim.Y1 && CurrentLocation.Y <= court.Hoop.InsideRim.Y2 + 20)
            {
                IsInHoop = true;
            }

            if (IsInHoop || CurrentLocation.Y >= court.Floor.FloorStart.Y)
            {
                FinishShot();
            }

            CurrentLocation = new Point(CurrentLocation.X, nextY);
        }

        //credits to https://github.com/tzxb018 for this function for simulating movement of the ball on the y axis
        public double YMovement(double speed, double theta, double time, double gravity) //makeshift gravity
        {
            double a = Math.Sin(theta * (Math.PI / 180));
            return (((speed*0.689 * a/2 * -10) * time + gravity * Math.Pow(time, 2)) / 100); //s = ut + .5at^2
        }

        public void Shoot(double power, int angle, int gravity, Court court)
        {
            if(IsInHoop && Form1.game.GetGameType().Equals(Constants.GAME_TYPE.TIMED))
            {
                FinishShot();
                return;
            }
            Power = power;
            IsShot = true;
            double nextX, nextY;
            //vertical travel of ball
            double dy = 1 * YMovement(Power, angle, SecondsSinceShot, gravity);
            nextY = CurrentLocation.Y + dy;
            //horizontal travel of ball
            nextX = CurrentLocation.X;
            if (IsBouncing == true)
            {
                double dx = Power * .5 * Math.Cos(angle * (3.14 / 180));
                dx /= 10;
                nextX -= (int)dx;

            }
            else
            {
                double dx = Power * Math.Cos(angle * (3.14 / 180));
                dx /= 10;
                nextX += (int)dx;
            }
            //if the ball hits the ground
            if(nextY > court.Floor.FloorStart.Y-2*Radius && !IsInHoop)
            {
                BounceCoef *= .7;
                Power *= BounceCoef;
                SecondsSinceShot = 0;
                SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_BallBounce);
                sp.Play();
                if (BounceCoef < .4 && Form1.game.GetGameType().Equals(Constants.GAME_TYPE.TIMED)) //if bounce coefficient make the bounces too small to distinguish on the screen
                {
                    nextY = InitialLocation.Y;
                    nextX = InitialLocation.X;
                    CurrentLocation = new Point(InitialLocation.X, InitialLocation.Y);
                    FinishShot();
                    BounceCoef = 1;
                    Power = 50;
                    IsInHoop = false;
                }
            }

            //if the ball goes out of bounds
            if ((nextX > Constants.FORM_WIDTH || nextX < 0) && Form1.game.GetGameType().Equals(Constants.GAME_TYPE.TIMED))
            {
                nextY = InitialLocation.Y;
                nextX = InitialLocation.X;
                CurrentLocation = new Point(InitialLocation.X, InitialLocation.Y);
                FinishShot();
                BounceCoef = 1;
                Power = 50;
            }
            //if it hits the backboard
            if(!IsBouncing && (nextX >= court.Hoop.BackboardStart.X && nextY >= court.Hoop.BackboardStart.Y && nextY <= court.Hoop.BackboardEnd.Y))
            {
                //rimIndex = -1;
                //lastStartX = (int)picBall.Location.X;
                //lastStartY = (int)picBall.Location.Y;
                IsBouncing = true;
                SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_Brick);
                sp.Play();
            }

            //if it bounces off from the front of the rim

            if(nextX >= court.Hoop.RimLeftStart.X && nextX <= court.Hoop.RimLeftEnd.X && nextY >= court.Hoop.RimLeftStart.Y)
            {
                IsBouncing = !IsBouncing;
                SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_Brick);
                sp.Play();
            }

            //if ball comes into contact with the pole
            if(nextX >= court.Hoop.PoleStart.X - 2*Radius && nextY >= court.Hoop.PoleStart.Y && nextY <= court.Hoop.PoleEnd.Y)
            {
                IsBouncing = true;
                SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_Brick);
                sp.Play();
            }

            //if ball goes inside hoop
            if (nextX + Radius  >= (int)court.Hoop.InsideRim.X1 && nextX + Radius <= (int)court.Hoop.InsideRim.X2 && nextY + Radius >= (int)court.Hoop.InsideRim.Y1 && !IsBouncing)
            {
                IsInHoop = true;
                Power *= .2;
                SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_Swish);
                sp.Play();
            }

            //if player scored, reset game state - for timed mode
            if(IsInHoop && Form1.game.GetGameType().Equals(Constants.GAME_TYPE.TIMED))
            {
                    nextX = InitialLocation.X;
                    nextY = InitialLocation.Y;
                    //FinishShot();
                    BounceCoef = 1;
                    Power = 50;
                    SecondsSinceShot = 0;
            }


            CurrentLocation = new Point((int)nextX, (int)nextY);
        }

        public void FinishShot()
        {
            IsShot = false;
            SecondsSinceShot = 0;
            IsInHoop = false;
            IsBouncing = false;
            //rimIndex = 1;
            //offRim = false;
        }

        public void DrawCurveFromBall(Graphics g, int angle)
        {
            List<Point> points = new List<Point>();
            SolidBrush b = new SolidBrush(Color.Black);
            Pen p = new Pen(b);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            for (double t = 1; t < 50; t += 1)
            {
                double dx;
                dx = Power * Math.Cos(angle * (3.14 / 180));
                dx /= 10;
                g.FillEllipse(b, (int)((InitialLocation.X+Radius) + (int)dx * t), (int)(CurrentLocation.Y+Radius + YMovement(Power, angle, t - 1, Previous.GRAVITY)), 4, 4);
                //points.Add(new Point((int)((InitialLocation.X) + (int)dx * t), (int)(CurrentLocation.Y + (45 / 2) + YMovement(Power, angle, t - 1, Freestyle.GRAVITY))));
            }
            //g.DrawCurve(p, points.ToArray());
            p.Dispose();
            b.Dispose();
        }

        public void Draw(Graphics g)
        {
            Bitmap img = new Bitmap(Hoops.Properties.Resources.basketball, 2*Radius,2*Radius);
            switch (RotationAngle)
            {
                case 0:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;
                case 90:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 180:
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 270:
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                default:
                    img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                    break;

            }
            RotationAngle +=90;
            if(RotationAngle == 360)
            {
                RotationAngle = 0;
            }
            g.DrawImage(img, CurrentLocation.X, CurrentLocation.Y, 2*Radius, 2*Radius);
            img.Dispose();
        }

        public void MoveLeft()
        {
            if (CurrentLocation.X - 5 > 0)
            {
                CurrentLocation = new Point(CurrentLocation.X - 5, CurrentLocation.Y);
            }
        }

        public void MoveRight()
        {
            if (CurrentLocation.X + 5 < Constants.POLE_START.X)
                CurrentLocation = new Point(CurrentLocation.X + 5, CurrentLocation.Y);
        }
    }
}
