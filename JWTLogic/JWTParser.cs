using System.IdentityModel.Tokens.Jwt;

namespace FindJobWebApi.JWTLogic
{
    public static class JWTParser
    {
        public static ulong parseToken(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = tokenHandler.ReadJwtToken(token).Claims.ToList();
            return ulong.Parse(claims[2].Value);
        }
    }
}
