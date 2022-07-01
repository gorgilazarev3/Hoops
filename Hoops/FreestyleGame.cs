using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class FreestyleGame : Game
    {
        Random Random;

        public FreestyleGame(Basketball basketball, Player player) : base(basketball, player)
        {
            this.Random = new Random();
            CanShoot = true;
            Player.IsDribbling = true;
        }

        public override void EndGame()
        {
            this.IsStarted = false;
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
            this.IsStarted = true;
        }
        
        public void InitiateShooting()
        {
            Power = Random.Next(50, 100);
            Angle = Random.Next(0, 90);
        }
    }
}
