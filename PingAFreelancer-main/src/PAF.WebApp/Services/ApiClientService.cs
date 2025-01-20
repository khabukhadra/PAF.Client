using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using PAF.WebApp.Models;
using Blazored.LocalStorage;
using Blazored;

namespace PAF.WebApp.Services;

public class ApiClientService : ApiClientBase, IFreelancerService
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly ILogger<ApiClientService> _logger;
    public ApiClientService(HttpClient client, ILocalStorageService localStorage,
        ILogger<ApiClientService> logger)
    {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:5136/api/");
        _localStorage = localStorage;
        _logger = logger;
    }

    public async Task<Domains> GetDomainsAsync()
    {
        var uri = "domains";
        return await GetTemplatedAsync<Domains>(_client, uri);
    }

    public async Task<Domain> GetDomainAsync(int domainId)
    {
        var uri = $"domain/{domainId}";
        return await GetTemplatedAsync<Domain>(_client, uri);
    }

    public async Task<Freelancers> GetFreelancersAsync(int id)
    {
        string uri = $"domains/{id}/freelancers";
        return await GetTemplatedAsync<Freelancers>(_client, uri);
    }

    public async Task<Freelancer> GetFreelancerByIdAsync(int domainId, string freelancerId)
    {
        var uri = $"domains/{domainId}/freelancers/{freelancerId}";
        var t = await GetTemplatedAsync<Freelancer>(_client, uri);
        return t;
    }

    public async Task<Freelancers> GetAllFreelancersAsync()
    {
        var uri = "freelancers";
        var freelancers = await GetTemplatedAsync<Freelancers>(_client, uri);
        return freelancers;
    }
    public async Task<Expertises> GetExpertisesAsync()
    {
        var uri = "expertises";
        var expertises = await GetTemplatedAsync<Expertises>(_client, uri);
        return expertises;
    }

    public async Task<Freelancers> CreateFilteredFreelancer(FreelancerFiltered filteredFreelancer)
    {
        var uri = "filter";
        var result = await PostTemplated<Freelancers, FreelancerFiltered>(_client, uri, filteredFreelancer);
        return result;
    }

    public async Task PingFreelancer(PingRequest pingRequest)
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        var uri = "auth/ping";
        var response = await _client.PostAsJsonAsync(uri, pingRequest);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to ping freelancer: {error}");
        }
    }

    public async Task ContractClient(Contract contract)
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        var uri = "auth/contract";
        var response = await _client.PostAsJsonAsync(uri, contract);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to contract with client: {error}");
        }
    }

    public async Task CompleteContract(Contract contract)
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        
        var uri = "auth/complete";
        var response = await _client.PostAsJsonAsync(uri, contract);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Failed to complete contract: {error}");
        }

    }

    public async Task<IEnumerable<PingRequest>> GetPings(string userId)
    {
        var uri = $"pings/{userId}";
        return await GetTemplatedAsync<IEnumerable<PingRequest>>(_client, uri);
    }


    public async Task<IEnumerable<Contract>> GetContracts(string userId)
    {
        var uri = $"contracts/{userId}";
        return await GetTemplatedAsync<IEnumerable<Contract>>(_client, uri);
    }

    public async Task<InteractionDetails> GetInteractionDetails(string freelancerId, string userId) {
        var uri = $"interactiondetails/{freelancerId}/{userId}";
        return await GetTemplatedAsync<InteractionDetails>(_client, uri);
    }

    public async Task<UserDetails> GetUserDetails(string userId) {
        var uri = $"getuserdetails/{userId}";
        return await GetTemplatedAsync<UserDetails>(_client, uri);
    }
}