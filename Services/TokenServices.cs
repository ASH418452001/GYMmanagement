﻿using GYMmanagement.Entities;
using GYMmanagement.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GYMmanagement.Services
{
    public class TokenServices: ITokenService
    
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _userManager;

        public TokenServices(IConfiguration config, UserManager<User> userManager)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
        }
        public async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)

            };
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role))); ;

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokendescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}