using ClientLibrary.Helper;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorWASM_App.Authentication
{
    // Custom authentication state provider to manage authentication state in Blazor
    public class CustomAuthStateProvider(ITokenService tokenService) : AuthenticationStateProvider
    {
        // Anonymous user representation
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        // Method to get the current authentication state
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Retrieve the JWT token from the token service
            string jwt = await tokenService.GetJWTTokenAsync(Constant.Cookie.Name);

            // If the token is null or empty, return an anonymous authentication state
            if (string.IsNullOrEmpty(jwt))
                return await Task.FromResult(new AuthenticationState(_anonymous));

            // Extract claims from the JWT token
            var claims = GetClaims(jwt);

            // If no claims are found, return an anonymous authentication state
            if (!claims.Any())
                return await Task.FromResult(new AuthenticationState(_anonymous));

            // Create a ClaimsPrincipal with the extracted claims
            var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));

            // Return the authentication state with the ClaimsPrincipal
            return await Task.FromResult(new AuthenticationState(claimPrincipal));
        }

        // Method to notify the authentication state has changed
        public void NotifyAuthenticationState()
        {
            // Notify the authentication state has changed
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        // Helper method to extract claims from a JWT token
        private static IEnumerable<Claim> GetClaims(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims.ToList();
        }
    }
}
