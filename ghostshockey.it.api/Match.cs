namespace ghosthockey.it.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Match()
        {
            MatchEvents = new HashSet<MatchEvent>();
            MatchStats = new HashSet<MatchStat>();
            Media = new HashSet<Medium>();
        }

        public int MatchID { get; set; }

        public int HomeTeamID { get; set; }

        public byte HomeTeamScore { get; set; }

        public int AwayTeamID { get; set; }

        public byte AwayTeamScore { get; set; }

        public DateTime MatchDate { get; set; }

        [StringLength(5)]
        public string MatchCode { get; set; }

        public int MatchRound { get; set; }

        public int MatchStatus { get; set; }

        public int MatchTypeID { get; set; }

        public int CategoryID { get; set; }

        public int YearID { get; set; }

        public int? TournamentID { get; set; }

        public int? StatTeamID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Team Team { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual MatchType MatchType { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual Year Year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchEvent> MatchEvents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchStat> MatchStats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }
    }
}
