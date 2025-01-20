using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Newtonsoft.Json;

namespace PAF.WebApp.Services;

public abstract class ApiClientBase
{
    public async Task<T> GetTemplatedAsync<T>(HttpClient client, string uri)
    {
        var response = await client.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            throw new Exception(message);
        }
        Console.WriteLine(response);
        return await response.Content.ReadFromJsonAsync<T>();
    }
    
public async Task<TResponse> PostTemplated<TResponse, TRequest>(HttpClient client, string uri, TRequest credentials)
{
    try 
    {
        var response = await client.PostAsJsonAsync(uri, credentials);
        
        // Log the full response for debugging
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Status Code: {response.StatusCode}");
        Console.WriteLine($"Response Content: {responseContent}");
        
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error Response: {responseContent}");
            throw new HttpRequestException($"Server Error: {responseContent}");
        }

        var result = await response.Content.ReadFromJsonAsync<TResponse>();
        return result ?? throw new Exception($"Failed to deserialize response to {typeof(TResponse).Name}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception Details: {ex.Message}");
        throw;
    }
}
}