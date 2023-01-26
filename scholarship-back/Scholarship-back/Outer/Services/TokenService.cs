using Microsoft.IdentityModel.Tokens;
using Scholarship_back.Outer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Scholarship_back.Outer.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(User userr)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userr.Name),
                new Claim(ClaimTypes.Role, userr.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
