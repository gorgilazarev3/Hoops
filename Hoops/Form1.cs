using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hoops
{
    public partial class Form1 : Form
    {
        //for timed example, (404,284) is ball initial
        //(338,49) - backboard start, (470,119) - backboard end
        //(374,100) rim left start (377,100) rim left end
        //(431,100) rim right start (434,100) rim right end
        //(404,120) pole start (404,306) pole end
        //(0,342) floor start, (809,342) floor end
        Point cursor;
        Point insideHoop = new Point(822, 268);
        //front of rim is 618,103
        //Freestyle game;
        Game game;
        //TimedGame tg;
        int numPresses = 0;
        int powerTicks = 0;
        public Form1()
        {
            InitializeComponent();
            cursor = Point.Empty;
            pbBall.Visible = false;
            //game = new Freestyle(insideHoop);
            game = new TimedGame(new Basketball(Constants.INITIAL_BALL_LOCATION, pbBall.Width / 2), new Player(Constants.INITIAL_PLAYER_LOCATION));
            //tg = new TimedGame(new Hoop(new Point(338, 49), new Point(470, 119), new Point(374, 100), new Point(377, 100), new Point(431, 100), new Point(434, 100), new Point(404, 120), new Point(404, 306)), new Floor(new Point(0, 342), new Point(809, 342)), new Basketball(new Point(404, 284)), new Player());
            this.DoubleBuffered = true;
            //pbFullCourt.Image = Hoops.Properties.Resources.basketball_court_outside_free_throw;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            //if (!game.PowerSet && game.IsStarted)
            //{
            //    double angle = GetAngleOfLineBetweenTwoPoints(game.Basketball.InitialLocation, cursor);
            //    game.Angle = (int)angle;
            //    Invalidate(true);
            //}
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = String.Format("Cursor: X={0}, Y={1}\nDifference: X={2}, Y={3}",cursor.X,cursor.Y,pbFullCourt.Width-cursor.X,pbFullCourt.Height-cursor.Y);
            //if (!game.IsStarted)
            //{
            //    game.StartGame(e.Location,pbBall.Width/2);
            //    Invalidate(true);
            //}
            Invalidate(true);
        }

        private void pbFullCourt_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = String.Format("Cursor: X={0}, Y={1}\nDifference: X={2}, Y={3}", cursor.X, cursor.Y, pbFullCourt.Width - cursor.X, pbFullCourt.Height - cursor.Y);
            //if (!game.IsStarted)
            //{
            //    game.StartGame(e.Location, pbBall.Width / 2);
            //    Invalidate(true);
            //}
            //if(!tg.IsStarted)
            //{
            //    tg.StartGame();
            //    Invalidate(true);
            //}
            Invalidate(true);
        }

        private void pbFullCourt_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
            if (!(game as TimedGame).PowerSet && game.IsStarted)
            {
                int pwr = Math.Abs(cursor.X - game.Basketball.InitialLocation.X + game.Basketball.Radius)/5;
                if (pwr > 100)
                    pwr = 100;
                if (pwr < 0)
                    pwr = 0;
                double angle = GetAngleOfLineBetweenTwoPoints(game.Basketball.InitialLocation, cursor);
                game.Angle = (int)angle;
                Invalidate(true);
            }
        }

        private void pbFullCourt_Paint(object sender, PaintEventArgs e)
        {
            if (game.IsStarted && !pbBall.Visible && !pbPlayer.Visible)
            {
                //pbBall.Parent = pbFullCourt;
                //pbPlayer.Parent = pbFullCourt;
                //pbBall.Location = new Point(game.Basketball.InitialLocation.X-pbBall.Width/2,game.Basketball.InitialLocation.Y-pbBall.Height/2);
                pbBall.Location = game.Basketball.InitialLocation;
                //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim1;
                //pbPlayer.SizeMode = PictureBoxSizeMode.AutoSize;
                //pbPlayer.Visible = true;
                pbBall.Visible = true;
            }
            if (!(game as TimedGame).PowerSet && game.IsStarted && !game.Basketball.IsShot)
            {
                //e.Graphics.DrawLine(new Pen(Color.Black), new Point(game.Basketball.InitialLocation.X + game.Basketball.Radius, game.Basketball.InitialLocation.Y + game.Basketball.Radius), cursor);
                game.DrawCurveFromBall(e.Graphics);
            }
            //if(game.Player.AnimationStarted && !game.Player.AnimationFinished)
            //{
            //    if(game.Player.AnimationStep == 1)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim1;
            //    }
            //    else if (game.Player.AnimationStep == 2)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim2;
            //    }
            //    else if (game.Player.AnimationStep == 3)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim3;
            //    }
            //    else if (game.Player.AnimationStep == 4)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim4;
            //    }
            //    else if (game.Player.AnimationStep == 5)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim5;
            //    }
            //    else if (game.Player.AnimationStep == 6)
            //    {
            //        pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim6;
            //    }
            //}
            //if (tg.IsStarted && !pbBall.Visible)
            //{
            //    pbBall.Parent = pbFullCourt;
            //    //pbBall.Location = new Point(game.Basketball.InitialLocation.X-pbBall.Width/2,game.Basketball.InitialLocation.Y-pbBall.Height/2);
            //    pbBall.Location = tg.Basketball.InitialLocation;
            //    pbBall.Visible = true;
            //}
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space && !(game as TimedGame).PowerSet)
            {
                if (game.IsStarted && game.CanShoot)
                {
                    numPresses++;
                    if (numPresses == 1)
                    {
                        pbPower.Enabled = true;
                        pbPower.Location = new Point(pbBall.Location.X, pbBall.Location.Y + 100);
                        pbPower.Visible = true;
                        game.Player.AnimationStep = 2;
                        game.Player.StartAnimation();
                        timerPower.Enabled = true;
                        timerPower.Start();

                    }
                    else if (numPresses == 2)
                    {
                        timerPower.Stop();
                        timerPower.Enabled = false;
                        pbPower.Visible = false;
                        if(pbPower.Value > 100)
                        {
                            pbPower.Value = 100;
                        }
                        game.Power = pbPower.Value;
                        game.Basketball.Power = pbPower.Value;
                        (game as TimedGame).PowerSet = true;
                        pbPower.Enabled = false;
                        pbPower.Value = 0;
                        pbPower.Visible = false;
                        pbPower.Enabled = false;
                        timerShootingBall.Enabled = true;
                        timerShootingBall.Start();
                        numPresses = 0;
                        //timerPlayerAnimation.Enabled = true;
                        //timerPlayerAnimation.Start();
                    }
                }
                //if(tg.IsStarted && !tg.Basketball.IsShot)
                //{
                //    timerShootingBall.Enabled = true;
                //}
            }
        }

        private void timerShootingBall_Tick(object sender, EventArgs e)
        {
            if (game.IsStarted && game.CanShoot)
            {
                game.Shoot();
                updateBallLocation();
                if (game.Basketball.IsInHoop)
                {
                    game.IsStarted = false;
                }
                Invalidate(true);
            }
            else
            {
                timerShootingBall.Stop();
                game.CanShoot = true;
            }
            //if(tg.IsStarted)
            //{
            //    tg.Shoot();
            //    updateBallLocation();
            //}
            //else
            //{
            //    timerShootingBall.Enabled = false;
            //}

        }

        private void updateBallLocation()
        {
            pbBall.Location = game.Basketball.CurrentLocation;
            //pbBall.Location = tg.Basketball.CurrentLocation;
        }

        private void timerPower_Tick(object sender, EventArgs e)
        {
            pbPower.PerformStep();
            if(pbPower.Value > 100)
            {
                pbPower.Value = 0;
            }
        }

        public static double GetAngleOfLineBetweenTwoPoints(Point p1, Point p2)
        {
            float xDiff = p2.X - p1.X;
            float yDiff = p2.Y - p1.Y;
            return -(Math.Atan2(yDiff, xDiff) * (180 / Math.PI));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(game.Basketball != null && game.IsStarted)
            updateBallLocation();
            //if (!game.PowerSet && game.IsStarted)
            //{
            //    game.DrawCurveFromBall(e.Graphics);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game.StartGame();
            pbBall.Parent = pbFullCourt;
        }

        private void timerPlayerAnimation_Tick(object sender, EventArgs e)
        {
            game.Player.Animate();
            Invalidate(true);
        }
    }
}
