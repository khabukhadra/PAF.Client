using System.Linq;
namespace PAF.MobileApp.Models;

public class Domains
{
    public IEnumerable<Domain> Items { get; set; } = Enumerable.Empty<Domain>();
}