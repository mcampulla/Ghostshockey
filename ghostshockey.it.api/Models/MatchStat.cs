namespace ghostshockey.it.api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchStat")]
    public partial class MatchStat
    {
        public int MatchStatID { get; set; }

        public int MatchID { get; set; }

        public virtual Match Match { get; set; }

        public int PlayerDataID { get; set; }

        public virtual PlayerData PlayerData { get; set; }

        public byte Goal { get; set; }

        public byte Assist { get; set; }

        public byte ShootIn { get; set; }

        public byte ShootOut { get; set; }

        public byte FaceOffWon { get; set; }

        public byte FaceOffLost { get; set; }

        public byte PuckWon { get; set; }

        public byte PuckLost { get; set; }

        public byte Penalty { get; set; }

        public byte Plus { get; set; }

        public byte Minus { get; set; }

        public byte Score { get; set; }
    }
}
