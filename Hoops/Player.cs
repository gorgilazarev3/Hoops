using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public string CurrentAnimation { get; set; }

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
        }

        public void Animate()
        {
            if(AnimationStarted)
            {
                AnimationStep++;
            }
            if(AnimationStep > Constants.TIMED_MODE_ANIMATION_STEPS)
            {
                AnimationFinished = true;
                AnimationStarted = false;
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
    }
}
