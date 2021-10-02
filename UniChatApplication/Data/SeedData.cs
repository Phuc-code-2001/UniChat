using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniChatApplication.Models;

namespace UniChatApplication.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniChatDbContext(serviceProvider.GetRequiredService<DbContextOptions<UniChatDbContext>>()))
            {
                if (context.Account.Any()) { return; }

                List<Account> accounts = new List<Account>()
                {
                    new Account() {Username="DungMoi", Password="123567", Role_id=2},
                    new Account() {Username="BangCuDai", Password="000000", Role_id=4}
                };
                
                foreach(Account item in accounts)
                {
                    if (item.IsValid()) context.Account.Add(item);
                    else
                    {
                        foreach(string key in item.InvalidMessages.Keys)
                        {
                            Console.WriteLine(item.InvalidMessages[key]);
                        }
                    }
                }
                
                context.SaveChanges();
            }
        }

    }
}
