using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

namespace DistributorAPI.Presentation.Mappers;

public static class ProductMapper
{
    public static Product ToEntity(ProductDto dto) =>
        new()
        {
            Sku = dto.Sku,
            Description = dto.Description,
            Price = dto.Price            
        };

    public static ProductDto ToDto(Product entity) =>
        new()
        {
            Id = entity.Id, // Added Id mapping
            Sku = entity.Sku,
            Description = entity.Description,
            Price = entity.Price            
        };
}
