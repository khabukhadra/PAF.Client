namespace PAF.MobileApp.Models;

public class Domain
{
    public required int Id { get; set; }

    public required string DomainName { get; set; }

    public required string PhotoPath { get; set; }

    public required string BorderColor { get; set; }

    public Freelancers Freelancers { get; set; } = new();
    public int FreelancerCount => Freelancers.Items.Count();

    public Expertises Expertises { get; set; } = new();
    public int ExpertiseCount => Expertises.Items.Count();
};