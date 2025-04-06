using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.ProductUseCases;

public class DeleteProductHandler(IProductRepository productRepository)
{
    public async Task Handle(Guid id)
    {
        var existingProduct = await productRepository.GetByIdAsync(id);
        if (existingProduct == null)
            throw new InvalidOperationException("Product not found.");

        await productRepository.DeleteAsync(id);
    }
}
