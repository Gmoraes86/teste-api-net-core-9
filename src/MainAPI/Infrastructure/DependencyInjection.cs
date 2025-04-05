using Microsoft.EntityFrameworkCore;
using MainAPI.Application;
using MainAPI.Domain.Interfaces;
using MainAPI.Infrastructure.Repositories;

namespace MainAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        // Configurar DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Registrar repositórios
        services.AddScoped<IDistributorRepository, DistributorRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        // Registrar casos de uso
        services.AddScoped<RegisterDistributorHandler>();

        return services;
    }
}