using System.Reflection.Metadata;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using PAF.WebApp.Services;
using PAF.WebApp.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace PAF.WebApp.Services;

public class AuthService : ApiClientBase, IAuthService
{
    private readonly HttpClient _client;
    private readonly ILocalStorageService _localStorage;
    private readonly CustomAuthStateProvider _customAuthStateProvider;
    // private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthService(
        HttpClient client,
        ILocalStorageService localStorage,
        // AuthenticationStateProvider authenticationStateProvider)
        CustomAuthStateProvider authenticationStateProvider)
    {
        _client = client;
        _client.BaseAddress = new Uri("http://localhost:5136/api/");
        _localStorage = localStorage;
        // _authenticationStateProvider = authenticationStateProvider;A
        _customAuthStateProvider = authenticationStateProvider;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterModel credentials)
    {
        var uri = "auth/register";
        return await PostTemplated<RegisterResponse, RegisterModel>(_client, uri, credentials);
    }

public async Task<bool> LoginAsync(LoginModel credentials)
{
    try
    {
        var uri = "auth/login";
        var token = await PostTemplated<TokenResponse, LoginModel>(_client, uri, credentials);
        
        // Let's verify the token isn't null or empty
        if (string.IsNullOrEmpty(token.Token))
        {
            Console.WriteLine("Token is null or empty");
            return false;
        }

        await _localStorage.SetItemAsync("authToken", token.Token);

        try
        {
            _customAuthStateProvider.NotifyUserAuthentication(token.Token);
        }
        catch (Exception authEx)
        {
            // This will help us see the specific error
            Console.WriteLine($"Auth notification failed: {authEx.GetType().Name} - {authEx.Message}");
            throw; // Re-throw to be caught by outer catch
        }

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
    
        return true;
    }
    catch (Exception ex)
    {
        // Log the actual exception
        Console.WriteLine($"Login failed: {ex.GetType().Name} - {ex.Message}");
        return false;
    }
}

    public async Task LogoutAsync()
    { 
        await _localStorage.RemoveItemAsync("authToken");
        // ((CustomAuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
        _customAuthStateProvider.NotifyUserLogout();
        _client.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (string.IsNullOrEmpty(token)) return false;
        return true;
    }

    public async Task<IEnumerable<Claim>> GetUserClaimsAsync()
    {
        // return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User.Claims;
        return (await _customAuthStateProvider.GetAuthenticationStateAsync()).User.Claims;
    }
}