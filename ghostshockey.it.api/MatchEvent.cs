namespace ghosthockey.it.api
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

        public int Icon { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        public int Time { get; set; }

        public int TimeSec { get; set; }

        public virtual Match Match { get; set; }
    }
}
