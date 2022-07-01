using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    public class Constants
    {
        public static Point BACKBOARD_START { get; set; } = new Point(1139, 378);
        public static Point BACKBOARD_END { get; set; } = new Point(1139, 509);
        public static Point RIM_LEFT_START { get; set; } = new Point(1010, 518);
        public static Point RIM_LEFT_END { get; set; } = new Point(1033, 518);
        public static Point RIM_RIGHT_START { get; set; } = new Point(1119, 518);
        public static Point RIM_RIGHT_END { get; set; } = new Point(1142, 518);
        public static Point POLE_START { get; set; } = new Point(1237, 550);
        public static Point POLE_END { get; set; } = new Point(1237, 844);
        public static Point FLOOR_START { get; set; } = new Point(0, 859);
        public static Point FLOOR_END { get; set; } = new Point(1219, 859);
        public static Point INITIAL_PLAYER_LOCATION { get; set; } = new Point(391, 628);
        public static Point INITIAL_BALL_LOCATION { get; set; } = new Point(547, 680);
        public static int TIMED_MODE_ANIMATION_STEPS { get; set; } = 6;
        public static int FREESTYLE_MODE_ANIMATION_STEPS { get; set; } = 7;

        public static int TIME_START_AMOUNT { get; set; } = 60;
        public static int GRAVITY { get; set; } = 5;
        public static int FORM_WIDTH { get; set; } = 1084;
        public static int FORM_HEIGHT { get; set; } = 818;
        public static Point SCOREBOARD_LOCATION { get; set; } = new Point(409,250);
        public static string SCORES_FILE_PATH { get; set; } = @"C:\Users\Lazarevi\Documents\test.hf";
        public static int PLAYER_IMAGE_WIDTH { get; set; } = 85;
        public static int PLAYER_IMAGE_HEIGHT { get; set; } = 216;
        public static int BASKETBALL_RADIUS { get; set; } = 45/2;

        public enum  GAME_TYPE 
        {
            TIMED,
            FREESTYLE
        }
    }
}
