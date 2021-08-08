using gym_back.Model;
using gym_back.Repositories;
using gym_back.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gym_back.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration config;
        private IAccountRepository accountRepository;

        public LoginService(IConfiguration config, IAccountRepository accountRepository)
        {
            this.config = config;
            this.accountRepository = accountRepository;
        }

        public async Task<Account> LoginUserAsync(string userId, string password)
        {
            var account = await accountRepository.GetAccountAsync(userId);
            var token = this.GenerateJSONWebToken();
            
            var accountReturn = new Account
            {
                accountName = userId,
                password = password,
                token = "Bearer " + token
            };           
            return accountReturn;
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
