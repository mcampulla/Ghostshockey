namespace ghostshockey.it.api.Models
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

        [ForeignKey("AwayTeamID")]
        [Column("Team1")]
        public virtual Team AwayTeam { get; set; }

        [ForeignKey("HomeTeamID")]
        [Column("Team")]
        public virtual Team HomeTeam { get; set; }

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

    //public static class MatchMapper
    //{
    //    public static Match MapToModel(this model.Poco.Match dto)
    //    {
    //        Match model = new Match();
    //        model.MatchID = dto.MatchID;
    //        model.AwayTeamID = dto.AwayTeamID;
    //        model.AwayTeamScore = dto.AwayTeamScore;
    //        model.CategoryID = dto.CategoryID;
    //        model.HomeTeamID = dto.HomeTeamID;
    //        model.HomeTeamScore = dto.HomeTeamScore;
    //        model.MatchCode = dto.MatchCode;
    //        model.MatchDate = dto.MatchDate;
    //        model.MatchRound = dto.MatchRound;
    //        model.MatchStatus = dto.MatchStatus;
    //        model.MatchTypeID = dto.MatchTypeID;
    //        model.StatTeamID = dto.StatTeamID;
    //        model.TournamentID = dto.TournamentID;
    //        model.YearID = dto.YearID;

    //        return model;
    //    }

    //    public static model.Poco.Match MapToDto(this Match model)
    //    {
    //        model.Poco.Match dto = new model.Poco.Match();
    //        dto.MatchID = model.MatchID;
    //        dto.AwayTeamID = model.AwayTeamID;
    //        dto.AwayTeam = model.AwayTeam.MapToDto();
    //        dto.AwayTeamScore = model.AwayTeamScore;
    //        dto.CategoryID = model.CategoryID;
    //        dto.HomeTeamID = model.HomeTeamID;
    //        dto.HomeTeam = model.HomeTeam.MapToDto();
    //        dto.HomeTeamScore = model.HomeTeamScore;
    //        dto.MatchCode = model.MatchCode;
    //        dto.MatchDate = model.MatchDate;
    //        dto.MatchRound = model.MatchRound;
    //        dto.MatchStatus = model.MatchStatus;
    //        dto.MatchTypeID = model.MatchTypeID;
    //        dto.StatTeamID = model.StatTeamID;
    //        dto.TournamentID = model.TournamentID;
    //        dto.YearID = model.YearID;

    //        return dto;
    //    }
    //}
}
