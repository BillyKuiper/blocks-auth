using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAuth.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string zipcode { get; set; }
        public string adress { get; set; }
        public string housenumber { get; set; }
        public string addition { get; set; }
        public string city { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }
}
