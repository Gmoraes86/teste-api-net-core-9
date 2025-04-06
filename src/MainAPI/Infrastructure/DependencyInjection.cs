using MainAPI.Infrastructure.Data;
using MainAPI.Infrastructure.Injections;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddDistributorServices();
        return services;
    }
}