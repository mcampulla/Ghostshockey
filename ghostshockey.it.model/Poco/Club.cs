using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class Club
    {
        public int ClubID { get; set; }
        public string Name { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string Cap { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public int Type { get; set; }
        public string Tag { get; set; }
        public string Icon { get; set; }

        public string DisplayName { get { return Name; } }
    }
}
