using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class Tournament
    {
        public int TournamentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        //public virtual ICollection<Match> Matches { get; set; }
    }
}
