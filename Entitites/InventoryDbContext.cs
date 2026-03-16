using Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.Entity<Category>().Property(p => p.Id).UseIdentityColumn(increment: 2);
        }
    }
}
