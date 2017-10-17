using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerData
{
    public class Summoner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
        public int AccountId { get; set; }

        /// <summary>News this instance.</summary>
        public Summoner()
        {
            //Blank
        }

        /// <summary>News the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="profileIconId">The profile icon identifier.</param>
        /// <param name="revisionDate">The revision date.</param>
        /// <param name="summonerLevel">The summoner level.</param>
        public Summoner(int id, string name, int profileIconId, long revisionDate, int summonerLevel, int accountId)
        {
            this.Id = id;
            this.Name = name;
            this.ProfileIconId = profileIconId;
            this.RevisionDate = revisionDate;
            this.SummonerLevel = summonerLevel;
            this.AccountId = accountId;
        }
    }
}
