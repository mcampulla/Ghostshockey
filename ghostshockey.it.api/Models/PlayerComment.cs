namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerComment")]
    public partial class PlayerComment
    {
        [Key]
        public int CommentID { get; set; }

        public int PlayerID { get; set; }

        [Required]
        [StringLength(4000)]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public virtual Player Player { get; set; }
    }
}
