namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerData")]
    public partial class PlayerData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerData()
        {
            //Media = new HashSet<Medium>();
            //PlayerDataTeams = new HashSet<PlayerDataTeam>();
        }

        public int PlayerDataID { get; set; }

        public int? Height { get; set; }

        public double? Weight { get; set; }

        public int Stick { get; set; }

        public int? Role { get; set; }

        [StringLength(2)]
        public string Number { get; set; }

        [StringLength(500)]
        public string Photo { get; set; }

        public int PlayerID { get; set; }

        public virtual Player Player { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public int YearID { get; set; }

        public virtual Year Year { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Team> Teams { get; set; }

   
    }
}
