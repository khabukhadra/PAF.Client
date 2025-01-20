using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models
{
    public class Contract
    {
        public int? Id { get; set; }

        public string? ClientId { get; set; }

        public string? FreelancerId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int? Rating { get; set; }

        public int? HoursContracted { get; set; }

        public int? AmountPaid { get; set; }
    }
}