using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.EntityFramework;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity<Category>(b =>
            {
                b.Property(c => c.CategoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid")
                    .HasColumnName("category_id");

                b.Property(c => c.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property(c => c.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnType("character varying(300)")
                    .HasColumnName("description");

                b.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)")
                    .HasColumnName("name");

                b.Property(c => c.Slug)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("slug");

                b.HasKey(c => c.CategoryId);

                b.ToTable("Categories");
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.Property(o => o.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property(o => o.OrderDate)
                    .HasColumnType("timestamp with time zone");

                b.Property(o => o.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnType("character varying(30)");

                b.Property(o => o.OrderTotal)
                    .HasColumnType("integer");

                b.Property(o => o.UserId)
                    .HasColumnType("uuid");

                b.HasKey(o => o.OrderId);

                b.HasIndex(o => o.UserId);

                b.ToTable("Orders");
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property(p => p.CategoryId)
                    .HasColumnType("uuid");

                b.Property(p => p.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                b.Property(p => p.Description)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(p => p.ImageUrl)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)");

                b.Property(p => p.Price)
                    .HasColumnType("double precision");

                b.Property(p => p.Quantity)
                    .HasColumnType("integer");

                b.Property(p => p.Shipping)
                    .HasColumnType("double precision");

                b.Property(p => p.Slug)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("character varying(100)");

                b.Property(p => p.Sold)
                    .HasColumnType("integer");

                b.HasKey(p => p.Id);

                b.HasIndex(p => p.CategoryId);

                b.ToTable("Products");
            });

            modelBuilder.Entity<User>(b =>
            {
                b.Property(u => u.UserId)
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uuid");

                b.Property(u => u.Address)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(u => u.CreatedAt)
                    .HasColumnType("timestamp with time zone");

                b.Property(u => u.Email)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(u => u.Image)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(u => u.IsAdmin)
                    .HasColumnType("boolean");

                b.Property(u => u.IsBanned)
                    .HasColumnType("boolean");

                b.Property(u => u.Name)
                    .IsRequired()
                    .HasColumnType("text");

                b.Property(u => u.Password)
                    .IsRequired()
                    .HasColumnType("text");

                b.HasKey(u => u.UserId);

                b.ToTable("Users");
            });

            modelBuilder.Entity<Product>(b =>
            {
                b.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation(p => p.Category);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.Navigation(c => c.Products);
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();

                b.Navigation(o => o.User);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.Navigation(u => u.Orders);
            });
#pragma warning restore 612, 618
        });
    }
}}
