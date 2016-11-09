using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghostshockey.it.model.Poco
{
    public class User
    {
        public int UserId;
        public string Email;
        public string Password;
        public DateTime? LoginDate;
        public string AuthAccessToken;
        public DateTime? AuthExpirationDate;
    }
}
