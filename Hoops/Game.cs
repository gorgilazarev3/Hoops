using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public abstract class Game
    {
        public Court Court { get; set; }
        public Basketball Basketball { get; set; }
        public Player Player { get; set; }
        public bool IsStarted { get; set; }
        public double Power { get; set; }
        public int Angle { get; set; }
        public bool CanShoot { get; set; }
        public Constants.GAME_TYPE TYPE_OF_GAME { get; set; }
        public bool PowerSet { get; set; }

        protected Game(Basketball basketball, Player player)
        {
            Court = new Court();
            Hoop hoop = new Hoop(Constants.BACKBOARD_START, Constants.BACKBOARD_END, Constants.RIM_LEFT_START, Constants.RIM_LEFT_END, Constants.RIM_RIGHT_START, Constants.RIM_RIGHT_END, Constants.POLE_START, Constants.POLE_END);
            Floor floor = new Floor(Constants.FLOOR_START, Constants.FLOOR_END);
            Court.Hoop = hoop;
            Court.Floor = floor;
            Basketball = basketball;
            Player = player;
            CanShoot = false;
            IsStarted = false;
            Power = 50;
            Angle = 45;
            PowerSet = false;
        }


        protected Game()
        {
            Court = new Court();
            IsStarted = false;
        }

        public abstract void StartGame();
        public abstract void Shoot();
        public abstract void EndGame();
        public virtual void InitializeCourt(Point backboardStart, Point backboardEnd, Point rimLeftStart, Point rimLeftEnd, Point rimRightStart, Point rimRightEnd, Point poleStart, Point poleEnd, Point floorStart, Point floorEnd)
        {
            if (Court == null)
            {
                Court = new Court();
            }
            Court.InitializeHoop(backboardStart, backboardEnd, rimLeftStart, rimLeftEnd, rimRightStart, rimRightEnd, poleStart, poleEnd);
            Court.InitializeFloor(floorStart, floorEnd);
        }
        public void DrawCurveFromBall(Graphics g)
        {
            Basketball.DrawCurveFromBall(g, Angle);
        }

        public void SetGameType(Constants.GAME_TYPE type)
        {
            TYPE_OF_GAME = type;
        }

        public Constants.GAME_TYPE GetGameType()
        {
            return TYPE_OF_GAME;
        }

    }
}
