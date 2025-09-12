using Microsoft.EntityFrameworkCore;
using product_management.Domain.Entities;

namespace product_management.Infraestructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
