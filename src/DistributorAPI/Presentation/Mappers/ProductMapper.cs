using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

namespace DistributorAPI.Presentation.Mappers;

public static class ProductMapper
{
    public static Product ToEntity(ProductDto dto) =>
        new()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
            // Removed Stock mapping
        };

    public static ProductDto ToDto(Product entity) =>
        new()
        {
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price
            // Removed Stock mapping
        };
}
