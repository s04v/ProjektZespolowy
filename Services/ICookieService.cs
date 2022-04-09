using System.Security.Claims;

namespace FindJobWebApi.Services
{
    public interface ICookieService
    {
        public ClaimsPrincipal GetClaimsPrincipal(string role, string token);
    } 
}
