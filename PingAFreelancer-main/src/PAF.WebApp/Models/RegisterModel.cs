using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PAF.MobileApp.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is required")]
    [EmailAddress]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty; 

    [Required(ErrorMessage = "First name required")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name required")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Latitude required")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Longitude required")]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Phone number required")]
    public string PhoneNumber { get; set; }

    public DateTime DateRegistered { get; set; } = DateTime.Now;

    public string? ExpertiseName { get; set; } 

    public double? HourlyRate { get; set; } 
}