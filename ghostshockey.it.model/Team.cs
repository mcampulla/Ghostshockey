using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public Club Club { get; set; }
        public int ClubID { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public string DisplayName { get { return Club.Name + " " + Category.Name; } }
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
