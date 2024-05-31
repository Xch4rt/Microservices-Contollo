using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Domain.Entities;
using UserService.Domain.Repositories;

namespace UserService.Infraestructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHanlder = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AuthenticationSettings:JwtKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["AuthenticationSettings:JwtExpireHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["AuthenticationSettings:JwtIssuer"],
                Audience = _configuration["AuthenticationSettings:JwtAudience"]
            };

            var token = tokenHanlder.CreateToken(tokenDescriptor);

            return tokenHanlder.WriteToken(token);
        }
    }
}
