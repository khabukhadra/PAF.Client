using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models
{
    public class PingRequest
    {
        public string ClientId { get; set; } = string.Empty;

        public string FreelancerId { get; set; } = string.Empty;

        public DateTime DatePinged { get; set; }
    }
}