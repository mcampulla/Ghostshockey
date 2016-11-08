using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model
{
    public class YearDto
    {
        public int YearID { get; set; }
        public string Name { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? IsCurrent { get; set; }
        public string DisplayName { get { return Name; } }
    }

    public class YearDtoComparer : IEqualityComparer<YearDto>
    {
        public bool Equals(YearDto x, YearDto y)
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

        public int GetHashCode(YearDto p)
        {
            int hCode = p.YearID.GetHashCode();
            return hCode;
        }
    }
}
