using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SummonerManager;
using SummonerData;

namespace SummonerDataConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            AggregatedSummoner SummonerA =  SummonerLibary.GetAggregatedSummonerStats("TarockPrime", "euw1");
            AggregatedSummoner SummonerB =  SummonerLibary.GetAggregatedSummonerStats("CommodoreAwesome", "euw1");
            AggregatedSummoner SummonerC = SummonerLibary.GetAggregatedSummonerStats("masterpooper", "euw1");
            AggregatedSummoner SummonerD = SummonerLibary.GetAggregatedSummonerStats("sea buckthorn", "euw1");

        }




    }
}
