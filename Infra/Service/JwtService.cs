using Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public JwtService(IConfiguration config)
        {
            this._config = config;
            _key = new(Encoding.UTF8.GetBytes(_config["Secret"]));
        }
        public string CreateToken(Core.Model.User user)
        {
            var ClaimsTypes = new List<Claim>
            {
                new Claim("Email",user.Email),
                new Claim("Tenant",user.Tenant.Nome)
            };
            SigningCredentials creds = new(_key, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(ClaimsTypes),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandle = new();
            var token = tokenHandle.CreateToken(tokenDescriptor);
            return tokenHandle.WriteToken(token);
        }
    }
}
