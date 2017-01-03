using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public partial class Match
    {
        public int MatchID { get; set; }
        public int HomeTeamID { get; set; }
        public Team HomeTeam { get; set; }
        public byte HomeTeamScore { get; set; }
        public int AwayTeamID { get; set; }
        public Team AwayTeam { get; set; }
        public byte AwayTeamScore { get; set; }
        public DateTime MatchDate { get; set; }
        public string MatchCode { get; set; }
        public int MatchRound { get; set; }
        public int MatchStatus { get; set; }
        public int MatchTypeID { get; set; }
        public virtual MatchType MatchType { get; set; }
        public int? TournamentID { get; set; }
        public virtual Tournament Tournament { get; set; }
        public int? StatTeamID { get; set; }
        public Team StatTeam { get; set; }
    }
}
