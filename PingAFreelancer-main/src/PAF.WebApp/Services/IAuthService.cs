using System.Security.Claims;
using PAF.MobileApp.Models;

namespace PAF.MobileApp.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterModel registerModel);
        Task<bool> LoginAsync(LoginModel credentials);
        Task LogoutAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<IEnumerable<Claim>> GetUserClaimsAsync();
    }
}