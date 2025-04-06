using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<Product> AddAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await context.Products.FindAsync(id);

    public async Task<List<Product>> GetAllAsync() =>
        await context.Products.ToListAsync();

    public async Task<Product> UpdateAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
