using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PAF.WebApp.Models;

namespace PAF.WebApp.Services
{
    public interface INavService
    {
        Task<List<NavItem>> GetAuthorizedMenuItemsAsync();
    }

    public class NavService : INavService
    {
        private readonly CustomAuthStateProvider _authStateProvider;

        private readonly List<NavItem> _menuItems = new()
        {
            new NavItem
            {
                Text = "Home",
                Url = "/",
                Icon = "oi oi-home"
            },
            new NavItem
            {
                Text = "Browse",
                Url = "/domainspage",
                Icon = "oi oi-people",
                RolesRequired = new[] { "Client" }
            }
        };

        public NavService(CustomAuthStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<List<NavItem>> GetAuthorizedMenuItemsAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            return _menuItems.Where(item => IsAuthorized(item, user)).ToList();
        }

        private bool IsAuthorized(NavItem item, ClaimsPrincipal user)
        {
            if (item.RolesRequired == null || !item.RolesRequired.Any())
            {
                return true;
            }
            return item.RolesRequired.Any(role => user.HasClaim(ClaimTypes.Role, role));
        }
        
    }
}