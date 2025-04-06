using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface IMainApiClient
{
    Task SendOrdersAsync(IEnumerable<Order> orders);
}
