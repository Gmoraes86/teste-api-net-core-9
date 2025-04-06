using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.ProductUseCases;

public class GetProductHandler(IProductRepository productRepository)
{
    public async Task<Product?> GetByIdAsync(Guid id) =>
        await productRepository.GetByIdAsync(id);

    public async Task<List<Product>> GetAllAsync() =>
        await productRepository.GetAllAsync();
}
