using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerData
{
    public class SummonerDataAggregator
    {
        public readonly SummonerGames SummonerGamesData;

        /// <summary>Initializes a new instance of the <see cref="SummonerDataAggregator"/> class.</summary>
        public SummonerDataAggregator( SummonerGames sg )
        {
            SummonerGamesData = sg;
        }

        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTime);
        }

        /// <summary>Calculates the averages.</summary>
        public AggregatedSummoner CalculateAverages()
        {
            int summonerId = SummonerGamesData.SummonerId;
            AggregatedSummoner ag = new AggregatedSummoner(summonerId);

            //Loop through each game and start accumulating the data and assign it to the aggregated Summoner for later use.
            foreach (Game g in SummonerGamesData.Games.AsParallel())
            {
                DateTime gameCreationTime = FromUnixTime(Convert.ToInt64(g.createDate));

                ag.AverageSummonerLevel = g.level;                                                                                    //Average level you end games at    *
                ag.AverageIpEarned += g.ipEarned;                                                                                           //Average amount of Ip per game     *
                ag.ChampionsPlayed[g.championId] = ag.ChampionsPlayed.ContainsKey(g.championId)?ag.ChampionsPlayed[g.championId]+ 1:1;      //Champions you have played
                ag.EarliestGame = gameCreationTime < ag.EarliestGame ? gameCreationTime : ag.EarliestGame;                                  //First game you played
                ag.LatestGame = gameCreationTime > ag.LatestGame ? gameCreationTime : ag.LatestGame;                                        //Last game you played
                g.fellowPlayers.ForEach(fp => ag.FellowPlayers[fp.summonerId] = ag.FellowPlayers.ContainsKey(fp.summonerId) ? ag.FellowPlayers[fp.summonerId] + 1 : 1); //Loop though each player and add there summoner Id to the list.
                ag.GameModesPlayed[g.gameMode] = ag.GameModesPlayed.ContainsKey(g.gameMode) ? ag.GameModesPlayed[g.gameMode] + 1 : 1;       //Game Modes Played
                ag.GameSubTypesPlayed[g.subType] = ag.GameSubTypesPlayed.ContainsKey(g.subType) ? ag.GameSubTypesPlayed[g.subType] + 1 : 1; //Game Sub Types Played
                ag.GameTypesPlayed[g.gameType] = ag.GameTypesPlayed.ContainsKey(g.gameType) ? ag.GameTypesPlayed[g.gameType] + 1 : 1;       //Game Types Played
                ag.InvalidGames_Count += g.invalid ? 1 : 0;                                                                                 //Invalid Games Count
                ag.MapIdsPlayed[g.mapId] = ag.MapIdsPlayed.ContainsKey(g.mapId) ? ag.MapIdsPlayed[g.mapId] + 1 : 1;                         //Maps Played
                ag.Spell1Used[g.spell1] = ag.Spell1Used.ContainsKey(g.spell1) ? ag.Spell1Used[g.spell1] + 1 : 1;                            //Spell1 Used
                ag.Spell2Used[g.spell2] = ag.Spell2Used.ContainsKey(g.spell2) ? ag.Spell2Used[g.spell2] + 1 : 1;                            //Spell2 Used
                ag.TeamIdPlayed[g.teamId] = ag.TeamIdPlayed.ContainsKey(g.teamId) ? ag.TeamIdPlayed[g.teamId] + 1 : 1;                      //Which Team you are on!

                //Game Statistics
                ag.Stats.AverageAssists += g.stats.assists;
                ag.Stats.AverageBarracksKilled += g.stats.barracksKilled.GetValueOrDefault(0);
                ag.Stats.AverageBountyLevel += g.stats.bountyLevel.GetValueOrDefault(0);
                ag.Stats.AverageChampionsKilled += g.stats.championsKilled.GetValueOrDefault(0);
                ag.Stats.AverageEndGamelevel += g.stats.level;
                ag.Stats.AverageGoldEarned += g.stats.goldEarned;
                ag.Stats.AverageGoldSpent += g.stats.goldSpent;
                ag.Stats.AverageKillingSprees += g.stats.killingSprees.GetValueOrDefault(0);
                ag.Stats.AverageLargestKillingSpree += g.stats.largestKillingSpree.GetValueOrDefault(0);
                ag.Stats.AverageLargestMultiKill += g.stats.largestMultiKill.GetValueOrDefault(0);
                ag.Stats.AverageMagicDamageDealtPlayer += g.stats.magicDamageDealtPlayer;
                ag.Stats.AverageMagicDamageDealtToChampions += g.stats.magicDamageDealtToChampions;
                ag.Stats.AverageMagicDamageTaken += g.stats.magicDamageTaken;
                ag.Stats.AverageMinionsKilled += g.stats.minionsKilled;
                ag.Stats.AverageNeutralMinionsKilled += g.stats.neutralMinionsKilled;
                ag.Stats.AverageNeutralMinionsKilledEnemyJungle += g.stats.neutralMinionsKilledEnemyJungle;
                ag.Stats.AverageNeutralMinionsKilledYourJungle += g.stats.neutralMinionsKilledYourJungle;
                ag.Stats.AverageNumDeaths += g.stats.numDeaths;
                ag.Stats.AveragePhysicalDamageDealtPlayer += g.stats.physicalDamageDealtPlayer;
                ag.Stats.AveragePhysicalDamageDealtToChampions += g.stats.physicalDamageDealtToChampions;
                ag.Stats.AveragePhysicalDamageTaken += g.stats.physicalDamageTaken;
                ag.Stats.AverageTimePlayed += g.stats.timePlayed;
                ag.Stats.AverageTotalDamageDealt += g.stats.totalDamageDealt;
                ag.Stats.AverageTotalDamageDealtToChampions += g.stats.totalDamageDealtToChampions;
                ag.Stats.AverageTotalDamageTaken += g.stats.totalDamageTaken;
                ag.Stats.AverageTotalHeal += g.stats.totalHeal;
                ag.Stats.AverageTotalTimeCrowdControlDealt += g.stats.totalTimeCrowdControlDealt;
                ag.Stats.AverageTotalUnitsHealed += g.stats.totalUnitsHealed;
                ag.Stats.AverageTrueDamageDealtPlayer += g.stats.trueDamageDealtPlayer;
                ag.Stats.AverageTrueDamageDealtToChampions += g.stats.trueDamageDealtToChampions;
                ag.Stats.AverageTrueDamageTaken += g.stats.trueDamageTaken;
                ag.Stats.AverageTurretsKilled += g.stats.turretsKilled.GetValueOrDefault(0);
                ag.Stats.AverageVisionWardsBought += g.stats.visionWardsBought;
                ag.Stats.AverageWardKilled += g.stats.wardKilled;
                ag.Stats.AverageWardPlaced += g.stats.wardPlaced;
                ag.Stats.wins_Count += g.stats.win ? 1:0;
                ag.Stats.AveragelargestCriticalStrike += g.stats.largestCriticalStrike.GetValueOrDefault(0);
                ag.Stats.item0_Purchased[g.stats.item0] = ag.Stats.item0_Purchased.ContainsKey(g.stats.item0) ? ag.Stats.item0_Purchased[g.stats.item0] + 1 : 1;
                ag.Stats.item1_Purchased[g.stats.item1] = ag.Stats.item1_Purchased.ContainsKey(g.stats.item1) ? ag.Stats.item1_Purchased[g.stats.item1] + 1 : 1;
                ag.Stats.item2_Purchased[g.stats.item2] = ag.Stats.item2_Purchased.ContainsKey(g.stats.item2) ? ag.Stats.item2_Purchased[g.stats.item2] + 1 : 1;
                ag.Stats.item3_Purchased[g.stats.item3] = ag.Stats.item3_Purchased.ContainsKey(g.stats.item3) ? ag.Stats.item3_Purchased[g.stats.item3] + 1 : 1;
                ag.Stats.item4_Purchased[g.stats.item4] = ag.Stats.item4_Purchased.ContainsKey(g.stats.item4) ? ag.Stats.item4_Purchased[g.stats.item4] + 1 : 1;
                ag.Stats.item5_Purchased[g.stats.item5] = ag.Stats.item5_Purchased.ContainsKey(g.stats.item5) ? ag.Stats.item5_Purchased[g.stats.item5] + 1 : 1;
                ag.Stats.item6_Purchased[g.stats.item6] = ag.Stats.item6_Purchased.ContainsKey(g.stats.item6) ? ag.Stats.item6_Purchased[g.stats.item6] + 1 : 1;
            }

            int gameCount = SummonerGamesData.Games.Count();

            // * End of loop calculations must be made
            ag.AverageIpEarned = CalaculateAverage(ag.AverageIpEarned);
            ag.Stats.AverageAssists = CalaculateAverage(ag.Stats.AverageAssists);
            ag.Stats.AverageBarracksKilled = CalaculateAverage(ag.Stats.AverageBarracksKilled);
            ag.Stats.AverageBountyLevel = CalaculateAverage(ag.Stats.AverageBountyLevel);
            ag.Stats.AverageChampionsKilled = CalaculateAverage(ag.Stats.AverageChampionsKilled);
            ag.Stats.AverageEndGamelevel = CalaculateAverage(ag.Stats.AverageEndGamelevel);
            ag.Stats.AverageGoldEarned = CalaculateAverage(ag.Stats.AverageGoldEarned);
            ag.Stats.AverageGoldSpent = CalaculateAverage(ag.Stats.AverageGoldSpent);
            ag.Stats.AverageKillingSprees = CalaculateAverage(ag.Stats.AverageKillingSprees);
            ag.Stats.AverageLargestKillingSpree = CalaculateAverage(ag.Stats.AverageLargestKillingSpree);
            ag.Stats.AverageLargestMultiKill = CalaculateAverage(ag.Stats.AverageLargestMultiKill);
            ag.Stats.AverageMagicDamageDealtPlayer = CalaculateAverage(ag.Stats.AverageMagicDamageDealtPlayer);
            ag.Stats.AverageMagicDamageDealtToChampions = CalaculateAverage(ag.Stats.AverageMagicDamageDealtToChampions);
            ag.Stats.AverageMagicDamageTaken = CalaculateAverage(ag.Stats.AverageMagicDamageTaken);
            ag.Stats.AverageMinionsKilled = CalaculateAverage(ag.Stats.AverageMinionsKilled);
            ag.Stats.AverageNeutralMinionsKilled = CalaculateAverage(ag.Stats.AverageNeutralMinionsKilled);
            ag.Stats.AverageNeutralMinionsKilledEnemyJungle = CalaculateAverage(ag.Stats.AverageNeutralMinionsKilledEnemyJungle);
            ag.Stats.AverageNeutralMinionsKilledYourJungle = CalaculateAverage(ag.Stats.AverageNeutralMinionsKilledYourJungle);
            ag.Stats.AverageNumDeaths = CalaculateAverage(ag.Stats.AverageNumDeaths);
            ag.Stats.AveragePhysicalDamageDealtPlayer = CalaculateAverage(ag.Stats.AveragePhysicalDamageDealtPlayer);
            ag.Stats.AveragePhysicalDamageDealtToChampions = CalaculateAverage(ag.Stats.AveragePhysicalDamageDealtToChampions);
            ag.Stats.AveragePhysicalDamageTaken = CalaculateAverage(ag.Stats.AveragePhysicalDamageTaken);
            ag.Stats.AverageTimePlayed = CalaculateAverage(ag.Stats.AverageTimePlayed);
            ag.Stats.AverageTotalDamageDealt = CalaculateAverage(ag.Stats.AverageTotalDamageDealt);
            ag.Stats.AverageTotalDamageDealtToChampions = CalaculateAverage(ag.Stats.AverageTotalDamageDealtToChampions);
            ag.Stats.AverageTotalDamageTaken = CalaculateAverage(ag.Stats.AverageTotalDamageTaken);
            ag.Stats.AverageTotalHeal = CalaculateAverage(ag.Stats.AverageTotalHeal);
            ag.Stats.AverageTotalTimeCrowdControlDealt = CalaculateAverage(ag.Stats.AverageTotalTimeCrowdControlDealt);
            ag.Stats.AverageTotalUnitsHealed = CalaculateAverage(ag.Stats.AverageTotalUnitsHealed);
            ag.Stats.AverageTrueDamageDealtPlayer = CalaculateAverage(ag.Stats.AverageTrueDamageDealtPlayer);
            ag.Stats.AverageTrueDamageDealtToChampions = CalaculateAverage(ag.Stats.AverageTrueDamageDealtToChampions);
            ag.Stats.AverageTrueDamageTaken = CalaculateAverage(ag.Stats.AverageTrueDamageTaken);
            ag.Stats.AverageTurretsKilled = CalaculateAverage(ag.Stats.AverageTurretsKilled);
            ag.Stats.AverageVisionWardsBought = CalaculateAverage(ag.Stats.AverageVisionWardsBought);
            ag.Stats.AverageWardKilled = CalaculateAverage(ag.Stats.AverageWardKilled);
            ag.Stats.AverageWardPlaced = CalaculateAverage(ag.Stats.AverageWardPlaced);
            ag.Stats.AveragelargestCriticalStrike = CalaculateAverage(ag.Stats.AveragelargestCriticalStrike);
      
            // TODO merge all item disctionaries    ag.Stats.ItemsAll_Purchased = ag.Stats.item0_Purchased.Concat(ag.Stats.item1_Purchased).ToDictionary(x=> x.Key,x => x.Value);
            ag.TotalGames = gameCount;
            
            //Stat Averages
            //Return the results
            return ag;
        }

        /// <summary>Calaculates the average.</summary>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        private decimal CalaculateAverage( decimal? total)
        {
            if (!total.HasValue) { return 0; }
            return  total.Value / SummonerGamesData.Games.Count();

        }

    }
}
