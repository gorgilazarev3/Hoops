using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoops
{
    [Serializable]
    public class HighScores
    {
        public List<Player> Players { get; set; }
        public static int TOP_NUM { get; set; } = 10;
        public string FileName { get; set; }

        public HighScores()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player p)
        {
            Players.Add(p);
        }

        public string TopPlayers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("List of top {0} players in Timed Mode:",TOP_NUM));
            int counter = 0;
            Players = Players.OrderByDescending(p => p.Points).ToList();
            foreach(Player p in Players) {
                if(counter <= TOP_NUM)
                {
                    sb.AppendLine(p.ToString());
                    counter++;
                }
            }
            return sb.ToString();
        }
    }
}
