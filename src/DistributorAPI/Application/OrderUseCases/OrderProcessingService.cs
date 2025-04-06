using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.OrderUseCases;

public class OrderProcessingService(IOrderRepository orderRepository, IMainApiClient mainApiClient)
{
    public async Task ProcessPendingOrdersAsync()
    {
        var pendingOrders = await orderRepository.GetPendingOrdersAsync();
        var totalQuantity = pendingOrders
            .SelectMany(o => o.OrderProducts)
            .Sum(op => op.Quantity);

        if (totalQuantity >= 1000)
        {
            await mainApiClient.SendOrdersAsync(pendingOrders);
            foreach (var order in pendingOrders)
            {
                order.Status = OrderStatus.Processed;
                await orderRepository.UpdateAsync(order);
            }
        }
    }
}
