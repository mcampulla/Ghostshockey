namespace ghosthockey.it.api
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerDataTeam")]
    public partial class PlayerDataTeam
    {
        [Key]
        public int RowID { get; set; }

        public int TeamID { get; set; }

        public int PlayerDataID { get; set; }

        public virtual PlayerData PlayerData { get; set; }

        public virtual Team Team { get; set; }
    }
}
