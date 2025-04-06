using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetAllAsync(bool includeCustomer = false); // Add includeCustomer parameter
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order?> GetByIdAsync(Guid id, bool includeCustomer = false); // Add includeCustomer parameter
    Task<Order> UpdateAsync(Order order); // Adicionado método UpdateAsync
    Task<List<Order>> GetPendingOrdersAsync();
}
