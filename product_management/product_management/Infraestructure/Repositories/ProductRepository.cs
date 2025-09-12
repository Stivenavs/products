using Microsoft.EntityFrameworkCore;
using product_management.Application.Abstractions;
using product_management.Domain.Entities;
using product_management.Infraestructure.Data;

namespace product_management.Infraestructure.Repositories
{
    public class ProductRepository(AppDbContext db) : IProductRepository
    {
        public async Task<List<Product>> GetAllAsync() => await db.Products.AsNoTracking().ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) => await db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<Product> SaveAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            db.Products.Remove(product);
            await db.SaveChangesAsync();           
        }

        public async Task UpdateAsync(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
    }
}
