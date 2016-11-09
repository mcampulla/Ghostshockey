using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class Year
    {
        public int YearID { get; set; }
        public string Name { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsCurrent { get; set; }
        public string DisplayName { get { return Name; } }
    }

    public class YearComparer : IEqualityComparer<Year>
    {
        public bool Equals(Year x, Year y)
        {
            if (x.YearID == y.YearID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(Year p)
        {
            int hCode = p.YearID.GetHashCode();
            return hCode;
        }
    }
}
