using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebshopAuth.Models
{
    public class ChangePassword
    {
        public string oldPW { get; set; }
        public string newPW { get; set; }
        public string confirmPW { get; set; }
    }
}
