using DistributorAPI.Domain.Entities;
using DistributorAPI.Presentation.DTOs;

namespace DistributorAPI.Presentation.Mappers;

public static class OrderMapper
{
    public static Order ToEntity(CreateOrderDto dto)
    {
        return new Order
        {
            CustomerId = dto.CustomerId,
            OrderProducts = dto.Products.Select(p => new OrderProduct
            {
                ProductId = p.ProductId, // Usar ProductId diretamente
                Quantity = p.Quantity
            }).ToList(),
            CreatedAt = DateTime.UtcNow
        };
    }

    public static OrderDto ToDto(Order entity)
    {
        return new OrderDto
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            CustomerName = entity.Customer.FullName, // Include Customer Name
            Products = entity.OrderProducts.Select(op => new ProductQuantityDto
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity,
                Description = op.Product.Description // Map Description
            }).ToList(),
            CreatedAt = entity.CreatedAt,
            Status = entity.Status.ToString()
        };
    }
}
