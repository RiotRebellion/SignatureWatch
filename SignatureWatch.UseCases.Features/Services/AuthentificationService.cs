using Microsoft.IdentityModel.Tokens;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Features.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignatureWatch.UseCases.Features.Services
{
    internal class AuthentificationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthentificationService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        internal Task<AuthentificationResponse> GenerateAuthentificationResponseForUserAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.Username)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = ""
            }
        }
    }
}
