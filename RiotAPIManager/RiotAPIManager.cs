using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SummonerData
{
    public class RiotAPIManager
    {
        private const string Key = "RGAPI-ce9e562a-5d63-48b7-9400-ec8b7316dbd5";

        /// <summary>Gets the URL response.</summary>
        /// <param name="sURL">The s URL.</param>
        /// <returns></returns>
        public static string GetUrlResponse(string sURL)
        {

            //Create a web request.
            WebRequest wrGETURL = WebRequest.Create(sURL);

            //Set up Web Proxy.
            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;

            //Get the objectStream and then read it.
            Stream objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string sLines = objReader.ReadToEnd();

            //Return the streamed text
            return sLines;

        }

        public static Summoner GetSummonerBySummonerName(string summonerName,string region)
        {
             string _summonerRequestURL = "https://"+region+".api.riotgames.com/lol/summoner/v3/summoners/by-name/" + summonerName+"?api_key="+Key;

            //Get the summoner using the summoner by name api command
            string urlResponseString = GetUrlResponse(_summonerRequestURL);

            //Create a summoner and assign the results to the summoner
            Summoner deserializedSummoner = new Summoner();
            deserializedSummoner = JsonConvert.DeserializeObject<Summoner>(urlResponseString);

            return deserializedSummoner;
        }

        public static SummonerGames GetGamesBySummonerId(string summonerId, string region)
        {
            string _requestURL = "https://"+region+ ".api.riotgames.com/lol/match/v3/matchlists/by-account/"+summonerId+"/recent?api_key=" + Key;

            //Get the summoner using the summoner by name api command
            string urlResponseString = GetUrlResponse(_requestURL);

            var jsonGames = JObject.Parse(urlResponseString);

            SummonerGames sg = JsonConvert.DeserializeObject<SummonerGames>(jsonGames.ToString());
            return sg;
        }
    }
}
