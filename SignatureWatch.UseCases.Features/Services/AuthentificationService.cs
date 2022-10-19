using Microsoft.IdentityModel.Tokens;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.Responses;
using SignatureWatch.UseCases.Contracts.Responses.Base;
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
        private readonly JwtOptions _jwtOptions;
        private readonly IDbContext _dbContext;

        public AuthentificationService(JwtOptions jwtOptions, IDbContext dbContext)
        {
            (_jwtOptions, _dbContext) = (jwtOptions, dbContext);
        }

        public async Task<AuthentificationResponse> LoginAsync(User user)
        {
            var isUserExist = _dbContext.Set<User>()
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password); 

            if (isUserExist == null)
            {
                return new AuthentificationResponse
                {
                    Errors = new[] { "Неправильный логин или пароль" }
                };
            }
            else
            {
                return await GenerateAuthentificationResponseForUserAsync(user);
            }          
        }

        public async Task<BaseResponse> RegisterAsync(User user)
        {
            var existingUser = _dbContext.Set<User>().
                FirstOrDefault(u => u.Username == user.Username && u.Email == user.Email);

            if (existingUser != null) 
            {
                return new BaseResponse
                {
                    Errors = new[] { "Пользователь с таким никнеймом или почтой уже существует" }
                };
            }
            else
            {
                _dbContext.Set<User>().Add(user);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    IsSuccess = true
                };
            }
            
        }

        private async Task<AuthentificationResponse> GenerateAuthentificationResponseForUserAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var claims = new List<Claim>
            {
                new Claim("Guid", user.Guid.ToString()),
                new Claim("UserName", user.Username),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {               
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.UtcNow.Add(_jwtOptions.TokenLifeTime),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(new AuthentificationResponse
            {
                IsSuccess = true,
                Username = user.Username,
                Token = jwtHandler.WriteToken(token)
            });
        }
    }
}
