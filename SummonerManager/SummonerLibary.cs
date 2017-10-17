using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummonerData;

namespace SummonerManager
{
    public class SummonerLibary
    {
        /// <summary>Gets the summoner stats.</summary>
        /// <param name="summonerName">Name of the summoner.</param>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        public static AggregatedSummoner GetAggregatedSummonerStats(string summonerName, string region)
        {
            Summoner s = RiotAPIManager.GetSummonerBySummonerName(summonerName, region);
            SummonerGames sg = RiotAPIManager.GetGamesBySummonerId(s.Id.ToString(), region);

            SummonerDataAggregator sda = new SummonerDataAggregator(sg);
            return sda.CalculateAverages();
        }
    }
}
