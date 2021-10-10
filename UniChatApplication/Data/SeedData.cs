using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UniChatApplication.Models;
using UniChatApplication.Daos;

namespace UniChatApplication.Data
{
    public class SeedData
    {
        
        public static void InitialAdminAccount(IServiceProvider serviceProvider){

            var context = new UniChatDbContext(serviceProvider.GetRequiredService<DbContextOptions<UniChatDbContext>>());

            if (context.AdminProfile.Any()) return;

            AdminProfile admin = new AdminProfile(){
                FullName="Huynh Tan Phuc",
                Email="phuchtce150394@fpt.edu.vn",
                Phone="0987499512",
                Gender=true,
                Account=AccountDAOs.CreateAccount("phuchtce150394", "123456", 3)
            };

            context.Add(admin);
            context.SaveChanges();

        }

    }
}