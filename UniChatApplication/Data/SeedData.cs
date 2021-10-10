using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniChatApplication.Daos;
using UniChatApplication.Models;

namespace UniChatApplication.Data
{
    public class SeedData
    {
        public static void InitialAdminAccount(IServiceProvider serviceProvider)
        {
            var context =
                new UniChatDbContext(serviceProvider
                        .GetRequiredService<DbContextOptions<UniChatDbContext>>(
                        ));

            if (context.AdminProfile.Any()) return;

            List<AdminProfile> admins =
                new List<AdminProfile>()
                {
                    new AdminProfile()
                    {
                        FullName = "Huynh Tan Phuc",
                        Email = "phuchtce150394@fpt.edu.vn",
                        Phone = "0987499512",
                        Gender = true,
                        Account = AccountDAOs.CreateAccount("phuchtce150394", "12345678", 3)
                    },
                    new AdminProfile()
                    {
                        FullName = "Nguyen Khanh Duy",
                        Email = "duynkce150519@fpt.edu.vn",
                        Phone = "0917924906",
                        Gender = true,
                        Account = AccountDAOs.CreateAccount("duynkce150519", "123456", 3)
                    },
                    new AdminProfile()
                    {
                        FullName = "Ly Tuan Dat",
                        Email = "datltce150718@fpt.edu.vn",
                        Phone = "0946883484",
                        Gender = true,
                        Account = AccountDAOs.CreateAccount("datltce150718", "0411", 3)
                    },
                    new AdminProfile()
                    {
                        FullName = "Dang Do Huu Bang",
                        Email = "bangddhce150240@fpt.edu.vn",
                        Phone = "0939430214",
                        Gender = true,
                        Account = AccountDAOs.CreateAccount("bangddhce150240", "123456", 3)
                    },
                    new AdminProfile()
                    {
                        FullName = "Tran Van Hao",
                        Email = "haotvce150521@fpt.edu.vn",
                        Phone = "0945689274",
                        Gender = true,
                        Account = AccountDAOs.CreateAccount("haotvce150521", "123456", 3)
                    },
                };

            context.AddRange(admins);
            context.SaveChanges();
        }
    }
}
