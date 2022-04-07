using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobWebApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly JWTSettings _jwtSettings;

        public TokenService(JWTSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        public string generateToken(int id, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(getClaims(id, role)),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginedUserToken = tokenHandler.WriteToken(token);


            return string.Empty;
        }

        private Claim[] getClaims(int id, string role)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Actor, id.ToString())
            };
        }
    }
}
