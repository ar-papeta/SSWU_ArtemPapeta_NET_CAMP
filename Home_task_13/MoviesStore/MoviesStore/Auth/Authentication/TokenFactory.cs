﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesStore.Auth.Authentication
{
    public class TokenFactory : ITokenFactory
    {
        private readonly IConfiguration _configuration;
        public TokenFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateAccessToken(string userId, string userRole)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, userRole),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetJwtKey()));

            var credetials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken(
                _configuration.GetSection("Jwt:Issuer").Value,
                _configuration.GetSection("Jwt:Audience").Value,
                claims,
                expires: DateTime.UtcNow.AddDays(15),
                signingCredentials: credetials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
