namespace ghosthockey.it.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchType")]
    public partial class MatchType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatchType()
        {
            Matches = new HashSet<Match>();
        }

        public int MatchTypeID { get; set; }

        [Column("MatchType")]
        [Required]
        [StringLength(100)]
        public string MatchType1 { get; set; }

        public int PeriodNumber { get; set; }

        public int PeriodLength { get; set; }

        public int BreakLength { get; set; }

        public bool Overtime { get; set; }

        public int OvertimeNumber { get; set; }

        public int OvertimeLength { get; set; }

        public int OvertimeBreakLength { get; set; }

        public bool GoldenGol { get; set; }

        public bool Penalty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match> Matches { get; set; }
    }
}
