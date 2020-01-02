using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Votings.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Votings.Shared.Extensions;
using Votings.Server.DAL.Models;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginService(IConfiguration configuration,
                               SignInManager<User> signInManager,
                               UserManager<User> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<LoginResult> Login(LoginModel login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return UserIsNullError();
            }

            if (!user.EmailConfirmed)
            {
                return EmailNotConfirmed();
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, false, false);

            if (!result.Succeeded)
            {
                return InvalidCredentials();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            claims.Add(new Claim(CustomClaimTypes.UserId, user.Id));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Success(token);
        }

        private LoginResult InvalidCredentials() => new LoginResult
        {
            Successful = false,
            Errors = "Username and password are invalid.".ObjectToArray()
        };

        private LoginResult Success(JwtSecurityToken token) => new LoginResult
        {
            Successful = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };

        private LoginResult UserIsNullError() => new LoginResult
        {
            Successful = false,
            Errors = "This email address is not registered in the system".ObjectToArray()
        };

        private LoginResult EmailNotConfirmed() => new LoginResult
        {
            Successful = false,
            Errors = "Please, confirm your email following the link on your email box".ObjectToArray()
        };
    }
}
