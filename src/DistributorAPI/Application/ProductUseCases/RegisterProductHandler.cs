using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.ProductUseCases;

public class RegisterProductHandler(IProductRepository productRepository)
{
    public async Task<Product> Handle(Product product)
    {
        return await productRepository.AddAsync(product);
    }
}
