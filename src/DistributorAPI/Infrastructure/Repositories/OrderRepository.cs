using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Infrastructure.Repositories;

public class OrderRepository(AppDbContext context) : IOrderRepository
{
    public async Task<Order> AddAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<List<Order>> GetAllAsync(bool includeCustomer = false)
    {
        var query = context.Orders.AsQueryable();
        if (includeCustomer)
            query = query.Include(o => o.Customer); // Include Customer
        return await query
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .Select(o => new Order
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CreatedAt = o.CreatedAt,
                Status = o.Status,
                OrderProducts = o.OrderProducts.Select(op => new OrderProduct
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    Quantity = op.Quantity,
                    Product = new Product
                    {
                        Id = op.Product.Id,
                        Sku = op.Product.Sku,
                        Description = op.Product.Description,
                        Price = op.Product.Price
                    }
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id, bool includeCustomer = false)
    {
        var query = context.Orders.AsQueryable();
        if (includeCustomer)
            query = query.Include(o => o.Customer); // Include Customer
        return await query
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .Select(o => new Order
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CreatedAt = o.CreatedAt,
                Status = o.Status,
                OrderProducts = o.OrderProducts.Select(op => new OrderProduct
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    Quantity = op.Quantity,
                    Product = new Product
                    {
                        Id = op.Product.Id,
                        Sku = op.Product.Sku,
                        Description = op.Product.Description, 
                        Price = op.Product.Price
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
        return order;
    }
}
