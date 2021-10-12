﻿using Microsoft.EntityFrameworkCore;
using UniChatApplication.Models;

namespace UniChatApplication.Data
{
    public class UniChatDbContext : DbContext
    {
        public UniChatDbContext(DbContextOptions<UniChatDbContext> options) : base(options) { }

        public DbSet<Account> Account { get; set; }

        public DbSet<Class> Class { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<AdminProfile> AdminProfile { get; set; }

        public DbSet<TeacherProfile> TeacherProfile { get; set; }

        public DbSet<StudentProfile> StudentProfile { get; set; }

        public DbSet<LoginCookie> LoginCookies {get; set;}
    }
}
