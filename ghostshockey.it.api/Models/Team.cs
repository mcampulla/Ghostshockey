using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.api.Models
{
    [Table("Team")]
    public class Team 
    {
        public Team()
        {
        }

        public int TeamID { get; set; }

        
        public int ClubID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }

        [ForeignKey("ClubID")]
        public virtual Club Club { get; set; }
    }

    public class TeamComparer : IEqualityComparer<Team>
    {
        public bool Equals(Team x, Team y)
        {
            if (x.TeamID == y.TeamID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Team p)
        {
            int hCode = p.TeamID.GetHashCode();
            return hCode;
        }
    }
}
