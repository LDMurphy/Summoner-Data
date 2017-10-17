using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerData
{
    public class AggregatedSummoner
    {
        public int SummonerId { get; set; }
        public int TotalGames { get; set; }
        public Dictionary<int, int> ChampionsPlayed { get; set; } = new Dictionary<int, int>();
        public DateTime EarliestGame { get; set; } = DateTime.Now;
        public DateTime LatestGame { get; set; } = DateTime.Now;
        public Dictionary<int,int> FellowPlayers { get; set; } = new Dictionary<int, int>();
        public Dictionary<string, int> GameModesPlayed { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> GameTypesPlayed { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> GameSubTypesPlayed { get; set; } = new Dictionary<string, int>();
        public int InvalidGames_Count { get; set; }
        public decimal AverageIpEarned { get; set; }
        public int AverageSummonerLevel { get; set; }
        public Dictionary<int, int> MapIdsPlayed { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Spell1Used { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> Spell2Used { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> TeamIdPlayed { get; set; } = new Dictionary<int, int>();
        public AggregatedSummonerStats Stats { get; set; } = new AggregatedSummonerStats();

        /// <summary>Initializes a new instance of the <see cref="AggregatedSummoner"/> class.</summary>
        /// <param name="summonerId">The summoner identifier.</param>
        public AggregatedSummoner(int summonerId)
        {
            SummonerId = summonerId;
        }

        public class AggregatedSummonerStats
        {
            public decimal AverageEndGamelevel { get; set; }
            public decimal AverageGoldEarned { get; set; }
            public decimal AverageNumDeaths { get; set; }
            public decimal AverageMinionsKilled { get; set; }
            public decimal AverageGoldSpent { get; set; }
            public decimal AverageTotalDamageDealt { get; set; }
            public decimal AverageTotalDamageTaken { get; set; }
            public decimal team_Count { get; set; }
            public decimal wins_Count { get; set; }
            public decimal AverageNeutralMinionsKilled { get; set; }
            public decimal AveragePhysicalDamageDealtPlayer { get; set; }
            public decimal AverageMagicDamageDealtPlayer { get; set; }
            public decimal AveragePhysicalDamageTaken { get; set; }
            public decimal AverageMagicDamageTaken { get; set; }
            public decimal AverageTimePlayed { get; set; }
            public decimal AverageTotalHeal { get; set; }
            public decimal AverageTotalUnitsHealed { get; set; }
            public decimal AverageAssists { get; set; }
            public Dictionary<int, int> item0_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item1_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item2_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item3_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item4_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item5_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int, int> item6_Purchased { get; set; } = new Dictionary<int, int>();
            public Dictionary<int,int> ItemsAll_Purchased { get; set; } = new Dictionary<int, int>();
            public decimal AverageMagicDamageDealtToChampions { get; set; }
            public decimal AveragePhysicalDamageDealtToChampions { get; set; }
            public decimal AverageTotalDamageDealtToChampions { get; set; }
            public decimal AverageTrueDamageDealtPlayer { get; set; }
            public decimal AverageTrueDamageDealtToChampions { get; set; }
            public decimal AverageTrueDamageTaken { get; set; }
            public decimal AverageWardKilled { get; set; }
            public decimal AverageWardPlaced { get; set; }
            public decimal AverageNeutralMinionsKilledEnemyJungle { get; set; }
            public decimal AverageNeutralMinionsKilledYourJungle { get; set; }
            public decimal AverageTotalTimeCrowdControlDealt { get; set; }
            public Dictionary<int,int> playerRoles { get; set; } = new Dictionary<int, int>();
            public Dictionary<int,int> playerPositions { get; set; } = new Dictionary<int, int>();
            public decimal AverageVisionWardsBought { get; set; }
            public decimal AverageTurretsKilled { get; set; }
            public decimal AverageChampionsKilled { get; set; }
            public decimal AverageLargestMultiKill { get; set; }
            public decimal AverageBarracksKilled { get; set; }
            public decimal AverageKillingSprees { get; set; }
            public decimal AverageLargestKillingSpree { get; set; }
            public decimal AveragelargestCriticalStrike { get; set; }
            public decimal AverageBountyLevel { get; set; }
        }
        //TODO Stats
    }
}
