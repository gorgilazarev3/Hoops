using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    [Serializable]
    public class Player
    {
        public Point Location { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public bool AnimationStarted { get; set; }
        public bool AnimationFinished { get; set; }
        public int AnimationStep { get; set; }
        public bool IsDribbling { get; set; }
        public bool IsRunning { get; set; }
        public bool HasBall { get; set; }
        public bool IsShooting { get; set; }
        public bool FinishedShooting { get; set; }
        public bool IsDunking { get; set; }
        public string CurrentAnimation { get; set; }
        public bool LeftOrientation { get; set; }

        public Player(Point location)
        {
            Location = location;
            ResetPlayer();
        }

        public Player()
        {
        }

        public void ResetPlayer()
        {
            Points = 0;
            AnimationFinished = false;
            AnimationStarted = false;
            IsDribbling = false;
            IsRunning = false;
            HasBall = false;
            IsShooting = false;
            FinishedShooting = false;
            AnimationStep = 1;
            Name = null;
            CurrentAnimation = "anim1";
            IsDunking = false;
            LeftOrientation = false;
        }

        public void Animate()
        {
            if(AnimationStarted)
            {
                AnimationStep++;
            }
            if(Form1.game.GetGameType().Equals(Constants.GAME_TYPE.TIMED))
            {
                if (AnimationStep > Constants.TIMED_MODE_ANIMATION_STEPS)
                {
                    AnimationFinished = true;
                    AnimationStarted = false;
                }
            }
            else
            {
                if (AnimationStep > Constants.FREESTYLE_MODE_ANIMATION_STEPS)
                {
                    AnimationFinished = true;
                    AnimationStarted = false;
                }
            }

        }

        public void StartAnimation()
        {
            AnimationStarted = true;
            AnimationFinished = false;
        }

        public void SetPlayerName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0} - Points:{1}", Name, Points);
        }

        public void Draw(Graphics g)
        {
            //if (AnimationStep == 1 && CurrentAnimation != "anim1")
            //{
            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim1;
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);
            //    CurrentAnimation = "anim1";
            //}
            //else if (AnimationStep == 2 && CurrentAnimation != "anim2")
            //{
            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim2;
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim2, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);
            //    CurrentAnimation = "anim2";
            //}
            //else if (AnimationStep == 3 && CurrentAnimation != "anim3")
            //{
            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim3;
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim3, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);

            //    CurrentAnimation = "anim3";
            //}
            //else if (AnimationStep == 4 && CurrentAnimation != "anim4")
            //{
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim4, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);

            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim4;
            //    CurrentAnimation = "anim4";
            //}
            //else if (AnimationStep == 5 && CurrentAnimation != "anim5")
            //{
            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim5;
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim5, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);
            //    CurrentAnimation = "anim5";
            //}
            //else if (AnimationStep == 6 && CurrentAnimation != "anim6")
            //{
            //    //pbPlayer.Image = Hoops.Properties.Resources.player_timed_mode_anim6;
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim6, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);
            //    CurrentAnimation = "anim6";
            //}
            //else
            //    g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH, Constants.PLAYER_IMAGE_HEIGHT);
            if(IsDribbling)
            {
                if (!AnimationStarted && CurrentAnimation == "anim1")
                {
                    CurrentAnimation = "idle_anim1";
                }
                if (!AnimationStarted && CurrentAnimation == "idle_anim1")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dribble_idle_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "idle_anim2";
                }
                else if (!AnimationStarted && CurrentAnimation == "idle_anim2")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dribble_idle_anim2, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_BallBounce);
                    sp.Play();
                    CurrentAnimation = "idle_anim1";
                }
            }

            else if(IsRunning)
            {
                if(AnimationStarted)
                {
                    if (CurrentAnimation == "anim1")
                    {
                        if(!LeftOrientation)
                        g.DrawImage(Hoops.Properties.Resources.player_dribble_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        else
                        {
                            Image img = new Bitmap(Hoops.Properties.Resources.player_dribble_anim1);
                            img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            g.DrawImage(img, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                            img.Dispose();                        
                        }
                        CurrentAnimation = "anim4";
                    }
                    else if (CurrentAnimation == "anim4")
                    {
                        if(!LeftOrientation)
                        g.DrawImage(Hoops.Properties.Resources.player_dribble_anim4, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        else
                        {
                            Image img = new Bitmap(Hoops.Properties.Resources.player_dribble_anim4);
                            img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                            g.DrawImage(img, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                            img.Dispose();
                        }
                        CurrentAnimation = "anim1";
                        SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_BallBounce);
                        sp.Play();
                    }


                    //if (AnimationStep == 1 && CurrentAnimation != "anim1")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim1";
                    //}
                    //else if (AnimationStep == 2 && CurrentAnimation != "anim2")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim2, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim2";
                    //}
                    //else if (AnimationStep == 3 && CurrentAnimation != "anim3")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim3, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim3";
                    //}
                    //else if (AnimationStep == 4 && CurrentAnimation != "anim4")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim4, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim4";
                    //    SoundPlayer sp = new SoundPlayer(Hoops.Properties.Resources.Basketball_BallBounce);
                    //    sp.Play();
                    //}
                    //else if (AnimationStep == 5 && CurrentAnimation != "anim5")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim5, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim5";
                    //}
                    //else if (AnimationStep == 6 && CurrentAnimation != "anim6")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim6, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "anim6";
                    //}
                    //else if (AnimationStep == 7 && CurrentAnimation != "anim7")
                    //{
                    //    g.DrawImage(Hoops.Properties.Resources.player_dribble_anim7, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    //    CurrentAnimation = "idle_anim1";
                    //    AnimationStarted = false;
                    //    IsRunning = false;
                    //    IsDribbling = true;
                    //}
                }

            }

            else if(IsShooting)
            {
                    if (AnimationStep == 1 && CurrentAnimation != "anim1")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim1";
                    }
                    else if (AnimationStep == 2 && CurrentAnimation != "anim2")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim2, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim2";
                    }
                    else if (AnimationStep == 3 && CurrentAnimation != "anim3")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim3, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim3";
                    }
                    else if (AnimationStep == 4 && CurrentAnimation != "anim4")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim4, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim4";
                    }
                    else if (AnimationStep == 5 && CurrentAnimation != "anim5")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim5, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim5";
                    }
                    else if (AnimationStep == 6 && CurrentAnimation != "anim6")
                    {
                        g.DrawImage(Hoops.Properties.Resources.player_timed_mode_anim6, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                        CurrentAnimation = "anim6";
                    }
            }

            else if (IsDunking)
            {
                if (AnimationStep == 1 && CurrentAnimation != "anim1")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim1, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim1";
                }
                else if (AnimationStep == 2 && CurrentAnimation != "anim2")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim2, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim2";
                }
                else if (AnimationStep == 3 && CurrentAnimation != "anim3")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim3, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim3";
                }
                else if (AnimationStep == 4 && CurrentAnimation != "anim4")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim4, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim4";
                }
                else if (AnimationStep == 5 && CurrentAnimation != "anim5")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim5, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim5";
                }
                else if (AnimationStep == 6 && CurrentAnimation != "anim6")
                {
                    g.DrawImage(Hoops.Properties.Resources.player_dunking_anim6, Location.X, Location.Y, Constants.PLAYER_IMAGE_WIDTH + 10, Constants.PLAYER_IMAGE_HEIGHT);
                    CurrentAnimation = "anim6";
                }
            }

        }

        public void MoveLeft()
        {
            if(Location.X - 5 > 0)
            {
                Location = new Point(Location.X - 5, Location.Y);
            }
        }

        public void MoveRight()
        {
            if(Location.X + 5 < Constants.POLE_START.X)
            Location = new Point(Location.X + 5, Location.Y);
        }
    }
}
