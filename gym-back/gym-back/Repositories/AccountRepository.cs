using gym_back.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private DbContextOptions<LoginContext> options;
        private LoginContext context;

        public AccountRepository()
        {
            this.options = new DbContextOptionsBuilder<LoginContext>()
                                .UseInMemoryDatabase(databaseName: "Test")
                                .Options;

            //using (var context = new LoginContext(this.options))
            //{
                var account = new Account { accountName = "admin", password = "123" };
                this.context = new LoginContext(this.options);
                this.context.Accounts.Add(account);
                this.context.SaveChanges();
            //}
        }

        public async Task<Account> GetAccountAsync(string accountName)
        {
            //using (var context = new LoginContext(this.options))
            //{
                var searchedAccount = await this.context.Accounts
                    .Where( account => account.accountName == accountName)
                    .FirstOrDefaultAsync();

                return searchedAccount;
            //}
        }
    }
}
