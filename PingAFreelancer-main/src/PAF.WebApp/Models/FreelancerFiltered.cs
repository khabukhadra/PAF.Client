using System.ComponentModel.DataAnnotations;

namespace PAF.MobileApp.Models;

public class FreelancerFiltered
{
    public string Name { get; set; }
    public string ExpertiseName { get; set; }
    public string Email { get; set; }
    public decimal MaxHourlyRate { get; set; }
    public decimal MinRating { get; set; }
    public decimal MaxDistance { get; set; }
    public double Latitude => 26.331763376356438;
    public double Longitude => 50.13123828533483;
}