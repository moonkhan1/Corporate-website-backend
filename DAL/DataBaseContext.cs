﻿using Microsoft.EntityFrameworkCore;
using Entities;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        //public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\SQL;Database=NetCoreWebApp1;User Id=sa;Password=40kup40daqulpuqirix;TrustServerCertificate=True;"); 
        }
        // FOR VERSION .NET 6 AND AFTER
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "Admin",
                    Surname = "Admin",
                    Password = "123456",
                    Username = "Admin",
                    Email = "admin@NetCoreWebApp1.net"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
