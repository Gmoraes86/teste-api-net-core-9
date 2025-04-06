using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.ProductUseCases;

public class UpdateProductHandler(IProductRepository productRepository)
{
    public async Task<Product> Handle(Product product)
    {
        var existingProduct = await productRepository.GetByIdAsync(product.Id);
        if (existingProduct == null)
            throw new InvalidOperationException("Product not found.");

        return await productRepository.UpdateAsync(product);
    }
}
