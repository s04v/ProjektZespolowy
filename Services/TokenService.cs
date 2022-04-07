using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindJobWebApi.Services
{
    public class TokenService : ITokenService
    {
        private object _jwtSettings;

        public string generateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey); // no secret key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    //new Claim(ClaimTypes.Email, login),
                    //new Claim(ClaimTypes.Role, result.Item2),
                    //new Claim(ClaimTypes.SerialNumber, result.Item1.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(45),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var loginedUserToken = tokenHandler.WriteToken(token);


            return string.Empty;
        }
    }
}
