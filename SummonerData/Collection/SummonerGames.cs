using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerData
{
    public class SummonerGames
    {
        public List<Match> matches { get; set; }
        public int EndIndex { get; set; }
        public int StartIndex { get; set; }
        public int TotalGames { get; set; }
    }
}
