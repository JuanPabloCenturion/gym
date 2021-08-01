using gym_back.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Repositories
{
    public class AccountRepository
    {
        private DbContextOptions<LoginContext> options;

        public AccountRepository()
        {
            this.options = new DbContextOptionsBuilder<LoginContext>()
                                .UseInMemoryDatabase(databaseName: "Test")
                                .Options;

            using (var context = new LoginContext(this.options))
            {
                var account = new Account { accountName = "admin", password = "123" };
                context.Accounts.Add(account);
                context.SaveChanges();
            }
        }

        public Account GetAccount(string accountName)
        {
            using (var context = new LoginContext(this.options))
            {
                var searchedAccount = context.Accounts
                    .Where( account => account.accountName == accountName)
                    .FirstOrDefault();

                return searchedAccount;
            }
        }
    }
}
