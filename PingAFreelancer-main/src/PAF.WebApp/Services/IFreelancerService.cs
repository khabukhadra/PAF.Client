using PAF.MobileApp.Models;

namespace PAF.MobileApp.Services;

public interface IFreelancerService
{
    Task<Domains> GetDomainsAsync();
    Task<Domain> GetDomainAsync(int domainId);
    Task<Freelancers> GetFreelancersAsync(int id);
    Task<Freelancer> GetFreelancerByIdAsync(int domainId, string freelancerId);
    Task<Freelancers> GetAllFreelancersAsync();
    Task<Expertises> GetExpertisesAsync();
    Task<Freelancers> CreateFilteredFreelancer(FreelancerFiltered f);
    Task PingFreelancer(PingRequest pingRequest);
    Task<IEnumerable<PingRequest>> GetPings(string userId);
    Task<InteractionDetails> GetInteractionDetails(string freelancerId, string userId);
    Task ContractClient(Contract contract);
    Task<IEnumerable<Contract>> GetContracts(string userId);
    Task CompleteContract(Contract contract);
}
