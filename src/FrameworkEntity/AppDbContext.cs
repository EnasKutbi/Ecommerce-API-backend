using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.EntityFramework
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) {} // Not Added yet but needed in connection
        public DbSet <Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {}
    }
}
// protected override void OnModelCreating(ModelBuilder modelBuilder){
//     modelBuilder.Entity<Product>().HasKey(p => p.Id);//make sure primary id as id
//     modelBuilder.Entity<Product>().Property(P => P.Id).IsRequired().ValueGeneratedOnAdd();
//     modelBuilder.Entity<Category>().HasMany(C => C.Products).withOne(P=>P.Category).hasForeignKey(P=>P.category_id);

// }}