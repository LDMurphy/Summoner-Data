using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerData
{
    public class Game
    {
        public object gameId { get; set; }
        public bool invalid { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public string subType { get; set; }
        public int mapId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1 { get; set; }
        public int spell2 { get; set; }
        public int level { get; set; }
        public int ipEarned { get; set; }
        public object createDate { get; set; }
        public List<FellowPlayer> fellowPlayers { get; set; }
        public Stats stats { get; set; }
    }

}
