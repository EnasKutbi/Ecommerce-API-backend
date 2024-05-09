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
<<<<<<< HEAD
        public DbSet <OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {
            /* builder.Entity<Product>(entity=>{
=======
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
            
>>>>>>> a5bd1c4b91212b2b9c100d5dd6e974905b118cd3
                entity.HasKey(p => p.Id);
                //entity.Property(p => p.Id).HasDefaultValue("uuid_generate_v4()");

                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Slug).IsRequired().HasMaxLength(100); ;
                entity.Property(p => p.ImageUrl);
                entity.Property(p => p.Description);
                entity.Property(p => p.Price).IsRequired();
                entity.Property(p => p.Quantity);
                entity.Property(p => p.Sold);
                entity.Property(p => p.Shipping);
                entity.Property(p => p.CategoryId);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

             });*/
            // --------------------Category--------------------
            builder.Entity<Category>().HasKey(c => c.CategoryId); //PK
            builder.Entity<Category>().Property(c => c.CategoryId).IsRequired().ValueGeneratedOnAdd();

            //builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            //builder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            //builder.Entity<Category>().Property(c => c.Description).HasDefaultValue(string.Empty);
            // Relationship
            //one-to-many relationship between Product & Category
            builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

            // one-to-many relationship between User & order
            builder.Entity<Order>()
            .HasOne(_ => _.User)
            .WithMany(_ => _.Orders)
            .HasForeignKey(_ => _.UserId);

            builder.Entity<Order>()
            .Property(_ => _.UserId)
            .IsRequired();


/*
            // one-to-many relationship between Product & Category
            builder.Entity<Product>()
            .HasOne(P=>P.Category)
            .WithMany(C=>C.Products)
            .HasForeignKey(C => C.CategoryId);
            // .HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>(entity=>{


            });
            builder.Entity<Product>()
            .HasOne(P => P.Category)
            .WithMany(C => C.Products)
            .HasForeignKey(C => C.CategoryId);
            //  .HasForeignKey(p => p.CategoryId);
            builder.Entity<Category>(entity =>
            {

                entity.HasKey(C => C.CategoryId);
                //entity.Property(p => p.Id).HasDefaultValue("uuid_generate_v4()");

                entity.Property(C => C.Name).IsRequired().HasMaxLength(100);
                entity.Property(C => C.Slug);
                entity.Property(p => p.Description);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            //relationship
            // entity.HasMany(c => c.Products).WithOne(P =>P.Category).HasForeignKey(p => p.CategoryId);
            });
<<<<<<< HEAD
*/

            // many-to-many relationship between Product & order

            builder.Entity<OrderItem>()
            .HasKey(oi => oi.OrderItemId);

            builder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi=> oi.OrderId);

            builder.Entity<OrderItem>()
            .HasOne(oi=> oi.Product)
            .WithMany(p=> p.OrderItems)
            .HasForeignKey(oi=>oi.ProductId);

            builder.Entity<OrderItem>()
           .Property(_ => _.Quantity)
           .IsRequired();

            builder.Entity<OrderItem>()
            .HasIndex(_ => new { _.OrderId , _.ProductId} )
            .IsUnique(); 

            
=======

                //relationship
                // entity.HasMany(c => c.Products).WithOne(P =>P.Category).HasForeignKey(p => p.CategoryId);


            });
            builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

>>>>>>> a5bd1c4b91212b2b9c100d5dd6e974905b118cd3
        }


        //protected override void OnModelCreating(ModelBuilder builder) { 
        /* sitting rules by Fluent API
        builder.Entity<Order>().HasKey(o => o.OrderId); // 1st role, check PK
        builder.Entity<Order>().Property(o => o.OrderId).IsRequired().ValueGeneratedOnAdd(); // Generated from DB
        builder.Entity<Order>().Property(o => o.OrderStatus).IsRequired();
        builder.Entity<Order>().Property(o => o.OrderTotal).IsRequired();
        builder.Entity<Order>().Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMPS");
        */
        //
        //}

    }
}