using DistributorAPI.Application.OrderUseCases;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Repositories;
using DistributorAPI.Infrastructure.BackgroundServices;

namespace DistributorAPI.Infrastructure.Injections;

public static class OrderInjection
{
    public static IServiceCollection AddOrderServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<CreateOrderHandler>();
        services.AddScoped<OrderProcessingService>();
        services.AddHostedService<OrderProcessingBackgroundService>();
        return services;
    }
}
