using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}
