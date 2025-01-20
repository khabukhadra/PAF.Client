using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAF.MobileApp.Models;

public class InteractionDetails
{
    public string FreelancerFirstName { get; set; } = string.Empty;
    public string FreelancerLastName { get; set; } = string.Empty;
    public string FreelancerPhotoPath { get; set; } = string.Empty;
    public string FreelancerPhoneNumber { get; set; } = string.Empty;
    public double Distance { get; set; }
    public DateTime? InteractionDate { get; set; }
    public bool IsActive { get; set; }
    public string ClientFirstName { get; set; }
    public string ClientLastName { get; set; }
    public string ClientPhoneNumber { get; set; }
}