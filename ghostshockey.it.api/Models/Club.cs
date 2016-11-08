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
    [Table("Club")]
    public class Club 
    {
        public Club()
        {
            Teams = new HashSet<Team>();
        }

        public int ClubID { get; set; }

        [Column("Club")]
        [StringLength(100)]
        public string Club1 { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(5)]
        public string Cap { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(2)]
        public string Region { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int? Type { get; set; }

        [StringLength(10)]
        public string Tag { get; set; }

        [StringLength(100)]
        public string Icon { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
