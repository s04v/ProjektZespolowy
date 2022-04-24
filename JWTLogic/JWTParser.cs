using System.IdentityModel.Tokens.Jwt;

namespace FindJobWebApi.JWTLogic
{
    public static class JWTParser
    {
        public static int parseToken(this string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var claims = tokenHandler.ReadJwtToken(token).Claims.ToList();
            //return Int32.Parse(claims[2].Value);
            // temp fix in here 
            var tokenDiv = token.Substring(token.IndexOf(' ') + 1);
            var claims = tokenHandler.ReadJwtToken(tokenDiv).Claims.ToList();
            return Int32.Parse(claims[1].Value);
        }
    }
}
