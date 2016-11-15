using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class MatchType
    {
        public int MatchTypeID { get; set; }
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
    }
}
