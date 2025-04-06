using DistributorAPI.Infrastructure.Data;
using DistributorAPI.Infrastructure.Injections;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddCustomerServices();
        services.AddProductServices();
        services.AddOrderServices();
        
        return services;
    }
}