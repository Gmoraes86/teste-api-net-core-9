using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using System.Net.Http.Json;
using DistributorAPI.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;

namespace DistributorAPI.Infrastructure.Services;

public class MainApiClient(HttpClient httpClient, IConfiguration configuration) : IMainApiClient
{
    private readonly string _mainApiUrl = configuration["MainApi:Url"] ?? throw new InvalidOperationException("MainApi:Url not set");
    private readonly string _distributorId = configuration["MainApi:DistributorId"] ?? throw new InvalidOperationException("MainApi:DistributorId not set");

    public async Task SendOrdersAsync(IEnumerable<Order> orders)
    {
        var payload = new
        {
            DistributorId = _distributorId,
            Orders = orders.Select(o => new
            {
                o.Id,
                o.CustomerId,
                Products = o.OrderProducts.Select(op => new
                {
                    op.ProductId,
                    op.Quantity
                })
            })
        };

        await RetryHelper.ExecuteWithRetryAsync(async () =>
        {
            var response = await httpClient.PostAsJsonAsync($"{_mainApiUrl}/orders", payload);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<MainApiResponse>();
            if (result == null)
                throw new InvalidOperationException("Invalid response from Main API");

            foreach (var order in orders)
            {
                var updatedOrder = result.Orders.FirstOrDefault(o => o.OrderId == order.Id);
                if (updatedOrder != null)
                {
                    order.Status = OrderStatus.Processed;                    
                }
            }
        });
    }

    private class MainApiResponse
    {
        public List<OrderResponse> Orders { get; set; } = new();
    }

    private class OrderResponse
    {
        public Guid OrderId { get; set; }
        public List<ProductResponse> Products { get; set; } = new();
    }

    private class ProductResponse
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
