namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerDoc")]
    public partial class PlayerDoc
    {
        [Key]
        public int DocID { get; set; }

        public int PlayerID { get; set; }

        [Required]
        [StringLength(2)]
        public string Type { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        [StringLength(20)]
        public string Number { get; set; }

        [StringLength(300)]
        public string Photo { get; set; }

        public virtual Player Player { get; set; }
    }
}
