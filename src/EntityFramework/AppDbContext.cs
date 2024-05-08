using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Service;
using Microsoft.EntityFrameworkCore;

namespace api.EntityFramework
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {} // Not Added yet but needed in connection
        public DbSet <User> Users { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            /* sitting rules by Fluent API
            builder.Entity<Order>().HasKey(o => o.OrderId); // 1st role, check PK
            builder.Entity<Order>().Property(o => o.OrderId).IsRequired().ValueGeneratedOnAdd(); // Generated from DB
            builder.Entity<Order>().Property(o => o.OrderStatus).IsRequired();
            builder.Entity<Order>().Property(o => o.OrderTotal).IsRequired();
            builder.Entity<Order>().Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMPS");
            */
            builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);
        }
    }
}