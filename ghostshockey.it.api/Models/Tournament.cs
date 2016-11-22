namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tournament")]
    public partial class Tournament
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Tournament()
        //{
        //    Matches = new HashSet<Match>();
        //}

        public int TournamentID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int YearID { get; set; }

        [ForeignKey("YearID")]
        public virtual Year Year { get; set; }

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match> Matches { get; set; }
    }

    //public static class TournamentMapper
    //{
    //    public static Tournament MapToModel(this model.Poco.Tournament dto)
    //    {
    //        Tournament model = new Tournament();
    //        model.TournamentID = dto.TournamentID;
    //        model.Tournament1 = dto.Name;
    //        model.Description = dto.Description;
    //        model.DateStart = dto.DateStart;
    //        model.DateEnd = dto.DateEnd;

    //        return model;
    //    }

    //    public static model.Poco.Tournament MapToDto(this Tournament model)
    //    {
    //        model.Poco.Tournament dto = new model.Poco.Tournament();
    //        dto.TournamentID = model.TournamentID;
    //        dto.Name = model.Tournament1;
    //        dto.Description = model.Description;
    //        dto.DateStart = model.DateStart;
    //        dto.DateEnd = model.DateEnd;

    //        return dto;
    //    }
    //}
}
