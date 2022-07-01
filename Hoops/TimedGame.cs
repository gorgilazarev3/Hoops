using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class TimedGame : Game
    {
        public int TimeLeft { get; set; }
        public int BarValue { get; set; }

        public TimedGame(Basketball basketball, Player player) : base(basketball,player)
        {
            TimeLeft = Constants.TIME_START_AMOUNT;
            BarValue = 0;
            PowerSet = false;
        }

        public TimedGame() : base()
        {
            TimeLeft = 0;
            PowerSet = false;

        }

        public void SetTimeLeft(int seconds)
        {
            TimeLeft = seconds;
        }

        public override void EndGame()
        {
            IsStarted = false;
        }

        public override void Shoot()
        {
            Basketball.SecondsSinceShot++;
            Basketball.Shoot(Power, Angle, Constants.GRAVITY, Court);
            if (!Basketball.IsShot)
            {
                CanShoot = false;
                PowerSet = false;
            }
        }

        public override void StartGame()
        {
            IsStarted = true;
            CanShoot = true;
        }


    }
}
