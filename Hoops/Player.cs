using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class Player
    {
        public Point Location { get; set; }
        public int Points { get; set; }
        public bool AnimationStarted { get; set; }
        public bool AnimationFinished { get; set; }
        public int AnimationStep { get; set; }
        public bool IsDribbling { get; set; }
        public bool IsRunning { get; set; }
        public bool HasBall { get; set; }
        public bool IsShooting { get; set; }
        public bool FinishedShooting { get; set; }

        public Player(Point location)
        {
            Location = location;
            Points = 0;
            AnimationFinished = false;
            AnimationStarted = false;
            IsDribbling = false;
            IsRunning = false;
            HasBall = false;
            IsShooting = false;
            FinishedShooting = false;
            AnimationStep = 1;
        }

        public Player()
        {
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
        }
    }
}
