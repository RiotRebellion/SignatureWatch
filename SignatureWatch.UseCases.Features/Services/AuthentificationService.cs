﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SignatureWatch.Domain.Entities;
using SignatureWatch.UseCases.Contracts.DTO;
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
            var isUserExist = _dbContext.Set<User>().FindAsync(user.Username, user.Password);

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
            var existingUser = _dbContext.Set<User>().FindAsync(user.Username, user.Email);

            if (existingUser == null) 
            {
                return new AuthentificationResponse
                {
                    Errors = new[] { "Пользователь с таким никнеймом или почтой уже существует" }
                };
            }

            await _dbContext.Set<User>().AddAsync(user);

            return await GenerateAuthentificationResponseForUserAsync(user);
        }

        private Task<AuthentificationResponse> GenerateAuthentificationResponseForUserAsync(User user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.Username),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = "http://localhost:59386",
                Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifeTime),
                SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);

            return Task.FromResult(new AuthentificationResponse
            {
                IsSuccess = true,
                Token = jwtHandler.WriteToken(token)
            });
        }
    }
}