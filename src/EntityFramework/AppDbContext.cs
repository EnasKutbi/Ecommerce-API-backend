using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Migrations;

// using api.Service;
using Microsoft.EntityFrameworkCore;

namespace api.EntityFramework
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {} // Not Added yet but needed in connection
        public DbSet <User> Users { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            /* sitting rules by Fluent API for Orders Table
            builder.Entity<Order>().HasKey(o => o.OrderId); // 1st role, check PK
            builder.Entity<Order>().Property(o => o.OrderId).IsRequired().ValueGeneratedOnAdd(); // Generated from DB
            builder.Entity<Order>().Property(o => o.OrderStatus).IsRequired();
            builder.Entity<Order>().Property(o => o.OrderTotal).IsRequired();
            builder.Entity<Order>().Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMPS");
            */
            builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

            builder.Entity<Product>(entity=>{
                entity.HasKey(p => p.Id);
                //entity.Property(p => p.Id).HasDefaultValue("uuid_generate_v4()");

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Slug).IsRequired().HasMaxLength(100);;
                entity.Property(p => p.ImageUrl);
                entity.Property(p => p.Description);
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.Quantity); 
                entity.Property(p => p.Sold); 
                entity.Property(p => p.Shipping);
                entity.Property(p => p.CategoryId);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                

             });
             builder.Entity<Product>()
             .HasOne(P=>P.Category)
             .WithMany(C=>C.Products)
             .HasForeignKey(C => C.CategoryId);
            //  .HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>(entity=>{
                entity.HasKey(C => C.CategoryId);
                //entity.Property(p => p.Id).HasDefaultValue("uuid_generate_v4()");

                entity.Property(C => C.Name).IsRequired().HasMaxLength(100);
                entity.Property(C => C.Slug);
                entity.Property(p => p.Description);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                //relationship
                // entity.HasMany(c => c.Products).WithOne(P =>P.Category).HasForeignKey(p => p.CategoryId);
                

             });
        }
    }
}