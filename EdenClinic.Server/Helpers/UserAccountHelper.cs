using EdenClinic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EdenClinic.Server.Helpers
{
    public class UserAccountHelper
    {
        public UserAccountHelper(IConfiguration config, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.Configurtion = config;
            this.userManager = userManager;
            this.context = context;
        }
        public IConfiguration Configurtion { get; }

        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        public async Task<IdentityUser> ValidateUser(UserLoginModel credentials)
        {
            var identityUser = await userManager.FindByEmailAsync(credentials.Email);
            if (identityUser != null)
            {
                var result = userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null : identityUser;
            }
            return null;
        }

        public object GenerateToken(IdentityUser identityUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configurtion["TokenKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, identityUser.UserName.ToString()), new Claim(ClaimTypes.Email, identityUser.Email) }),
                Expires = DateTime.UtcNow.AddDays(300),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                //Audience = "*",
                //Issuer = "*"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public async Task<(Person User, string Message)> Login(UserLoginModel model) 
        {
            IdentityUser identityUser;
            if (model == null || (identityUser = await ValidateUser(model)) == null)
            {
                return (User: null, Message: "Login Failed");
            }
            var token = GenerateToken(identityUser);
            var item = context.Persons
                .Include(it=> it.Role)
                .FirstOrDefault(it => it.ApplicationUserID == identityUser.Id);
            item.AccessToken = token.ToString();
            return (User: item, Message: "Ok");

        }
    }
}
