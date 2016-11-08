namespace ghosthockey.it.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        [Key]
        public int MediaID { get; set; }

        public int? PlayerDataID { get; set; }

        public int? MatchID { get; set; }

        public int MediaType { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Url { get; set; }

        public virtual Match Match { get; set; }

        public virtual PlayerData PlayerData { get; set; }
    }
}
