namespace PAF.MobileApp.Models;

public class Expertise
{
    public int Id { get; set; }
    public string ExpertiseName { get; set; }
    public string PhotoPath { get; set; }
    public string BorderColor { get; set; }
    public Freelancers Freelancers { get; set; }
    public int ExpertiseCount => Freelancers.Items.Count();
}