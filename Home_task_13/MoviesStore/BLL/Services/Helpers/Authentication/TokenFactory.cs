using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MoviesStore.Authentication
{
    public class TokenFactory : ITokenFactory
    {
        private readonly IConfiguration _configuration;
        public TokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(string userId, string userRole)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, userRole),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            var credetials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                _configuration.GetSection("Jwt:Issuer").Value,
                _configuration.GetSection("Jwt:Audience").Value,
                claims,
                expires: DateTime.MaxValue,
                signingCredentials: credetials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
