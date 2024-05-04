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
        public DbSet <Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder) {}
    }
}