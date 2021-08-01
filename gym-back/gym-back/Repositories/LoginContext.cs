using gym_back.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Repositories
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions<LoginContext> options)
        : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }
    }
}
