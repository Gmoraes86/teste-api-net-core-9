using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using System.Net.Http.Json;

namespace DistributorAPI.Infrastructure.Services;

public class MainApiClient(HttpClient httpClient) : IMainApiClient
{
    public async Task SendOrdersAsync(IEnumerable<Order> orders)
    {
        var response = await httpClient.PostAsJsonAsync("https://api.main.com/orders", orders);
        response.EnsureSuccessStatusCode();
    }
}
