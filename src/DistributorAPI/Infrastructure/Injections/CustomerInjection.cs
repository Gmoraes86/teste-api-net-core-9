using DistributorAPI.Application.CustomerUseCases;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Repositories;
using DistributorAPI.Presentation.Validations;

namespace DistributorAPI.Infrastructure.Injections;

public static class CustomerInjection
{
    public static IServiceCollection AddCustomerServices(this IServiceCollection services)
    {
        services.AddScoped<RegisterCustomerValidationFilter>();
        services.AddScoped<UpdateCustomerValidationFilter>();

        // Registrar repositórios relacionados a Customer
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();

        // Registrar casos de uso relacionados a Customer
        services.AddScoped<RegisterCustomerHandler>();
        services.AddScoped<GetCustomerHandler>();
        services.AddScoped<UpdateCustomerHandler>();
        services.AddScoped<DeleteCustomerHandler>();

        return services;
    }
}