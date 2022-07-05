using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Features.Options;
using SignatureWatch.UseCases.Features.Services.Interfaces;
using SignatureWatch.UseCases.Gateways;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SignatureWatch.UseCases.Features.Services
{
    internal class AuthentificationService : IAuthentification
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDbContext _dbContext;

        public AuthentificationService(JwtSettings jwtSettings, IDbContext dbContext)
        {
            (_jwtSettings, _dbContext) = (jwtSettings, dbContext);
        }

        public async Task<AuthentificationResponse> LoginAsync(User user)
        {
            var isUserExist = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password); 

            if (isUserExist == null)
            {
                return new AuthentificationResponse
                {
                    Errors = new[] { "Неправильный логин или пароль" }
                };
            }

            return await GenerateAuthentificationResponseForUserAsync(user);
        }

        public async Task<AuthentificationResponse> RegisterAsync(User user)
        {
            var existingUser = await _dbContext.Set<User>().
                FirstOrDefaultAsync(u => u.Username == user.Username && u.Email == user.Email);

            if (existingUser != null) 
            {
                return new AuthentificationResponse
                {
                    Errors = new[] { "Пользователь с таким никнеймом или почтой уже существует" }
                };
            }

            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return await GenerateAuthentificationResponseForUserAsync(user);
        }

        private async Task<AuthentificationResponse> GenerateAuthentificationResponseForUserAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim("Guid", user.Guid.ToString()),
                new Claim("UserName", user.Username),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "SignatureWatch",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
                SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(new AuthentificationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }
    }
}
