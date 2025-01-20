namespace PAF.MobileApp.Models;

public class Freelancer
{
    public required string Id { get; set; }
    public required int DomainId { get; set; }
    public Expertise Expertise { get; set; }
    public List<string> OtherExpertises { get; set; } = new();
    public int NumberOfSkills => OtherExpertises.Count() + 1;
    public required int HoursBilled { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public required DateTime DateRegistered { get; set; }
    public required string PhotoPath { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required decimal HourlyRate { get; set; }
    public required decimal Rating { get; set; }
    public required int FulfilledContracts { get; set; }
    public required decimal Latitude { get; set; }
    public required decimal Longitude { get; set; }
    public required bool IsActive { get; set; }
}
