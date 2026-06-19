using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WpfApp3.Models;

namespace WpfApp3.Contexts
{
    public class MyContext : DbContext
    {
        String connectionString = "Server=WIN-C4UM3B4G5HP; Trusted_Connection=True;" + "Database=bd; TrustServerCertificate=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
