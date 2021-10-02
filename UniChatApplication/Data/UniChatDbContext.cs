using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;

namespace UniChatApplication.Data
{
    public class UniChatDbContext : DbContext
    {
        public UniChatDbContext(DbContextOptions<UniChatDbContext> options)
            : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<Account> Account { get; set; }

    }
}
