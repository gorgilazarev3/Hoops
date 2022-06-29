﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        HighScores scores;
        public Form1()
        {
            InitializeComponent();
            cursor = Point.Empty;
            pbBall.Visible = false;
            //game = new Freestyle(insideHoop);
            game = new TimedGame(new Basketball(Constants.INITIAL_BALL_LOCATION, pbBall.Width / 2), new Player(Constants.INITIAL_PLAYER_LOCATION));
            //tg = new TimedGame(new Hoop(new Point(338, 49), new Point(470, 119), new Point(374, 100), new Point(377, 100), new Point(431, 100), new Point(434, 100), new Point(404, 120), new Point(404, 306)), new Floor(new Point(0, 342), new Point(809, 342)), new Basketball(new Point(404, 284)), new Player());
            this.DoubleBuffered = true;
            Deserialize();
            pbFullCourt.Size = new Size(Constants.FORM_WIDTH, Constants.FORM_HEIGHT);
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
                pbPlayer.Parent = pbFullCourt;
                //pbBall.Location = new Point(game.Basketball.InitialLocation.X-pbBall.Width/2,game.Basketball.InitialLocation.Y-pbBall.Height/2);
                pbBall.Location = game.Basketball.InitialLocation;
                pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim1;
                pbPlayer.SizeMode = PictureBoxSizeMode.AutoSize;
                pbPlayer.Visible = true;
                //pbBall.Visible = true;
            }
            if (!(game as TimedGame).PowerSet && game.IsStarted && !game.Basketball.IsShot)
            {
                //e.Graphics.DrawLine(new Pen(Color.Black), new Point(game.Basketball.InitialLocation.X + game.Basketball.Radius, game.Basketball.InitialLocation.Y + game.Basketball.Radius), cursor);
                game.DrawCurveFromBall(e.Graphics);
            }
            updateScoreboard();
            updateTimeLeft();
            if(game.Player.AnimationFinished)
            {
                //pbBall.Visible = true;
                game.Basketball.Draw(e.Graphics);
            }
            else
            {
                //pbBall.Visible = false;
            }
            //game.Player.Draw(e.Graphics);
            updatePlayerMovement();
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
                        Invalidate(true);

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
                        //timerShootingBall.Enabled = true;
                        //timerShootingBall.Start();
                        numPresses = 0;
                        timerPlayerAnimation.Enabled = true;
                        timerPlayerAnimation.Start();
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
                    (game as TimedGame).Player.Points++;
                    updateScoreboard();
                }
                Invalidate(true);
            }
            else
            {
                timerShootingBall.Stop();
                game.Player.StartAnimation();
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
            //game.StartGame();
            //timerTimeLeft.Enabled = true;
            //timerTimeLeft.Start();
            //pbBall.Parent = pbFullCourt;
        }

        private void timerPlayerAnimation_Tick(object sender, EventArgs e)
        {
            game.Player.Animate();
            if(game.Player.AnimationStep > Constants.TIMED_MODE_ANIMATION_STEPS)
            {
                timerShootingBall.Enabled = true;
                timerShootingBall.Start();
                timerPlayerAnimation.Stop();
                game.Player.AnimationStep = 1;
            }
            Invalidate(true);
        }

        private void updateScoreboard()
        {
            if(game.IsStarted)
            {
                lblScoreboard.Text = game.Player.Points.ToString();
            }
        }

        private void updateTimeLeft()
        {
            if (game.IsStarted)
            {
                lblTimeLeft.Text = (game as TimedGame).TimeLeft >= 60 ? String.Format("{0:00}:{1:00}", (game as TimedGame).TimeLeft / 60, (game as TimedGame).TimeLeft % 60) : String.Format("00:{00}", (game as TimedGame).TimeLeft);
            }
        }

        private void timerTimeLeft_Tick(object sender, EventArgs e)
        {
            (game as TimedGame).TimeLeft--;
            updateTimeLeft();
            if((game as TimedGame).TimeLeft == 0)
            {
                timerTimeLeft.Stop();
                MessageBox.Show("GAME OVER, you have scored " + game.Player.Points + " points.");
                PlayerForm form = new PlayerForm();
                if(form.ShowDialog() == DialogResult.OK)
                {
                    game.Player.SetPlayerName(form.PlayerName);
                    scores.AddPlayer(game.Player);
                    game.Player = new Player(Constants.INITIAL_PLAYER_LOCATION);
                }
                SaveFile();
                if(scores.Players.Count > 0)
                MessageBox.Show(scores.TopPlayers());
                this.Close();
            }
            Invalidate(true);
        }

        private void Deserialize()
        {
            try
            {
                using (FileStream fs = File.OpenRead(Constants.SCORES_FILE_PATH))
                {
                    IFormatter bf = new BinaryFormatter();
                    scores = (HighScores)bf.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                scores = new HighScores();
            }

        }

        private void SaveFile()
        {
            if (scores.FileName == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Hoops File (*.hf) | *.hf";
                sfd.Title = "Save Score";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    scores.FileName = sfd.FileName;
                }
            }
            Serialize();
        }

        private void Serialize()
        {
            using (FileStream fs = File.Create(scores.FileName))
            {
                IFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, scores);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Left)
            //{
            //    game.Player.Location = new Point(game.Player.Location.X - 1, game.Player.Location.Y);
            //    updateScreen();
            //}
        }

        public void updatePlayerMovement()
        {
            if (game.Player.AnimationStarted && !game.Player.AnimationFinished)
            {
                if (game.Player.AnimationStep == 1 && game.Player.CurrentAnimation != "anim1")
                {
                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim1;
                    game.Player.CurrentAnimation = "anim1";
                }
                else if (game.Player.AnimationStep == 2 && game.Player.CurrentAnimation != "anim2")
                {
                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim2;
                    game.Player.CurrentAnimation = "anim2";
                }
                else if (game.Player.AnimationStep == 3 && game.Player.CurrentAnimation != "anim3")
                {
                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim3;

                    game.Player.CurrentAnimation = "anim3";
                }
                else if (game.Player.AnimationStep == 4 && game.Player.CurrentAnimation != "anim4")
                {

                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim4;
                    game.Player.CurrentAnimation = "anim4";
                }
                else if (game.Player.AnimationStep == 5 && game.Player.CurrentAnimation != "anim5")
                {
                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim5;
                    game.Player.CurrentAnimation = "anim5";
                }
                else if (game.Player.AnimationStep == 6 && game.Player.CurrentAnimation != "anim6")
                {
                    pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim6;
                    game.Player.CurrentAnimation = "anim6";
                }
            }
        }

        public void updateScreen()
        {
            //Image img = new Bitmap(pbFullCourt.Size.Width, pbFullCourt.Size.Height);
            //Graphics g = Graphics.FromImage(img);
            //g.DrawImage(Hoops.Properties.Resources.basketball_court_timed_mode, 0, 0, pbFullCourt.Width, pbFullCourt.Height);
            //g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim1, game.Player.Location);
            //pbFullCourt.Image = img;
            Invalidate(true);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if(e.KeyCode == Keys.Left)
            //{
            //    e.IsInputKey = true;
            //}
        }

        private void pbExitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbStartGame_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            game.StartGame();
            timerTimeLeft.Enabled = true;
            timerTimeLeft.Start();
            pbBall.Parent = pbFullCourt;
        }
    }
}
