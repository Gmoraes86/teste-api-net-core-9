using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

public static class ProductMapper
{
    public static ProductDto ToDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Sku = product.Sku,
            Description = product.Description,
            Price = product.Price
        };
    }

    public static Product ToEntity(ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Sku = productDto.Sku, 
            Description = productDto.Description,
            Price = productDto.Price
        };
    }
}
