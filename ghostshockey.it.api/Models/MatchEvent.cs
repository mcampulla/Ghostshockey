namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchEvent")]
    public partial class MatchEvent
    {
        public int MatchEventID { get; set; }

        public int MatchID { get; set; }

        public virtual Match Match { get; set; }

        public int Icon { get; set; }

        public int Period { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public int Minute { get; set; }

        public int Second { get; set; }
    }
}
