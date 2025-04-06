using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.OrderUseCases;

public class CreateOrderHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
{
    public async Task<Order> Handle(Guid customerId, List<(Guid ProductId, int Quantity)> productDetails)
    {
        var customer = await customerRepository.GetByIdAsync(customerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        var products = new List<OrderProduct>();
        foreach (var (productId, quantity) in productDetails)
        {
            var product = await productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            products.Add(new OrderProduct { Product = product, Quantity = quantity });
        }

        var order = new Order
        {
            CustomerId = customerId,
            OrderProducts = products, // Corrigido para usar OrderProducts
            CreatedAt = DateTime.UtcNow
        };

        return await orderRepository.AddAsync(order);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await orderRepository.GetAllAsync(includeCustomer: true); // Include Customer
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await orderRepository.GetByIdAsync(id, includeCustomer: true); // Include Customer
    }

    public async Task<Order> UpdateStatusAsync(Guid orderId, OrderStatus newStatus)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new InvalidOperationException("Order not found.");

        order.Status = newStatus;
        return await orderRepository.UpdateAsync(order);
    }
}
