using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ghostshockey.it.api.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FacebookId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
        public DateTime? LoginDate { get; set; } 
        public string AuthAccessToken { get; set; }
        public DateTime? AuthExpirationDate { get; set; }
    }
}