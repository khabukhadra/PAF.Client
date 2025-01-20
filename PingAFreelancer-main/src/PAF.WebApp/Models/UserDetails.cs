using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models
{
    public class UserDetails
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public double Distance { get; set; }
    }
}