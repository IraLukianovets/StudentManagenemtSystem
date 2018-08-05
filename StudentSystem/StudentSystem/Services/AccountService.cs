using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using StudentSystem.API.AppSettings;
using StudentSystem.API.Models;
using StudentSystem.API.Services.Absractions;
using StudentSystem.DAL;
using StudentSystem.DAL.Commands.ApplicationUser;
using StudentSystem.DAL.Entities;
using StudentSystem.DTO;

namespace StudentSystem.API.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(ApplicationDbContext dbContext) : base(dbContext)
        { }

        /// <summary>
        /// Authorizates user in system
        /// </summary>
        /// <param name="account">Instance of <see cref="AuthRequestApiModel"/> class</param>
        /// <returns>Returns instance of <see cref="AuthResponseApiModel"/> class or null</returns>
        public async Task<AuthResponseApiModel> Auth(AuthRequestApiModel account)
        {
            var dbCommand = new GetUserCommand(dbContext, account.Username);
            var user = await dbCommand.ExecuteAsync();

            if (user != null)
            {
                var identity = GetIdentity(user);

                if (identity != null)
                {
                    var token = GenerateToken(identity);

                    if (token != null)
                    {
                        var encodedToken = EncodeToken(token);

                        return new AuthResponseApiModel
                        {
                            AccessToken = encodedToken,
                            Username = identity.Name,
                            Role = user.Role.Name,
                            Email = user.Email
                        };
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Generated token
        /// </summary>
        /// <param name="identity">Instance of <see cref="ClaimsIdentity"/> class</param>
        /// <returns>Instance of <see cref="JwtSecurityToken"/> class</returns>
        private JwtSecurityToken GenerateToken(ClaimsIdentity identity)
        {
            var currenctTime = DateTime.UtcNow;

            return new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: currenctTime,
                claims: identity.Claims,
                expires: currenctTime.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        }

        /// <summary>
        /// Encodes toke
        /// </summary>
        /// <param name="token">Instance of <see cref="JwtSecurityToken"/>"/> class</param>
        /// <returns></returns>
        private string EncodeToken(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Returns instance of <see cref="ClaimsIdentity"/> class
        /// </summary>
        /// <returns>Returns instance of <see cref="ClaimsIdentity"/> class</returns>
        private ClaimsIdentity GetIdentity(ApplicationUser user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };

                return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            }

            return null;
        }

        public async Task<bool> Register(RegisterRequestApiModel user)
        {
            var result = false;
            try
            {
                var userData = Mapper.Map<RegisterRequestApiModel, RegisterUserDTO>(user);
                var dbCommand = new CreateUserCommand(dbContext, userData);
                result = await dbCommand.ExecuteAsync();              
            }
            catch
            {
                // TODO: Add log here
            }

            return result;
        }
    }
}
