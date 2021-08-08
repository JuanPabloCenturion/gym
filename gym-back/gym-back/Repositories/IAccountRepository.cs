using gym_back.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Repositories
{
    public interface IAccountRepository
    {
        public Task<Account> GetAccountAsync(string accountName);
    }
}
