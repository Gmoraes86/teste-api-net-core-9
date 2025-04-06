using DistributorAPI.Application.OrderUseCases;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Repositories;

namespace DistributorAPI.Infrastructure.Injections;

public static class OrderInjection
{
    public static IServiceCollection AddOrderServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<CreateOrderHandler>();
        return services;
    }
}
