using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Blazored.SessionStorage;

namespace LightsOut.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private ISessionStorageService _sessionStorageService;
        
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorageService = sessionStorage;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var username = await _sessionStorageService.GetItemAsync<string>("username");
            ClaimsIdentity identity;
            
            if (username != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    }, "apiauth_typre");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
           
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, username),
            }, "apiauth_typre");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("username");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}