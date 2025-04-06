using MainAPI.Application.DistributorUseCases;
using MainAPI.Domain.Interfaces;
using MainAPI.Infrastructure.Repositories;
using MainAPI.Presentation.Validations;

namespace MainAPI.Infrastructure.Injections;

public static class DistributorInjection
{
    public static IServiceCollection AddDistributorServices(this IServiceCollection services)
    {
        services.AddScoped<RegisterDistributorValidationFilter>();

        // Registrar repositórios relacionados a Distributor
        services.AddScoped<IDistributorRepository, DistributorRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        // Registrar casos de uso relacionados a Distributor
        services.AddScoped<RegisterDistributorHandler>();
        services.AddScoped<GetDistributorHandler>();
        services.AddScoped<UpdateDistributorHandler>();
        services.AddScoped<DeleteDistributorHandler>();

        return services;
    }
}