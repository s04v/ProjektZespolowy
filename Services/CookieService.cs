using System.Security.Claims;

namespace FindJobWebApi.Services
{
    public class CookieService : ICookieService
    {
        public CookieService()
        {

        }
        public ClaimsPrincipal GetClaimsPrincipal(string role, string token)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "Company"),
                new Claim(ClaimTypes.Name, token)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Cookie");
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
