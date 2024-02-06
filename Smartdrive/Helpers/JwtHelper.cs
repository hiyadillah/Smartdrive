using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using Smartdrive.Common;
using Smartdrive.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Smartdrive.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        public JwtHelper(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string CreateToken(User user, List<UserRole> userRoles)
        {
            //JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Sub, user.UserEntityid.ToString()),
                new(JwtRegisteredClaimNames.Email, user.UserEmail)
            };

            claims.Add(new(CustomClaims.Username, user.UserName));
            claims.Add(new(CustomClaims.Fullname, user.UserFullName));

            //claims roles
            foreach (var role in userRoles)
            {
                claims.Add(new(CustomClaims.Roles, role.UsroRoleName));
                claims.Add(new Claim(ClaimTypes.Role, role.UsroRoleName));
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:JwtSecret").Value));


            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(120),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
