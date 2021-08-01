using gym_back.Model;
using gym_back.Repositories;
using gym_back.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Services
{
    public class LoginService : ILoginService
    {
        public Account LoginUser(string userId, string password)
        {
            var repository = new AccountRepository();
            var account = repository.GetAccount(userId);
            
            return account;
        }
    }
}
