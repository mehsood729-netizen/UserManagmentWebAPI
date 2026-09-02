using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagmentWebAPI.Data.Entities;

namespace UserManagmentWebAPI.Utilities
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateJWT(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role,user.Role.ToString())

            };
            var apitoken = _configuration["APIToken"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(apitoken!));
            var cread = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "www.OCMS.Com",
                Audience = "ThisTokenONLYvalidForOCMSUsers",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = cread
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
