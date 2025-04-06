using DistributorAPI.Application.ProductUseCases;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Repositories;
using DistributorAPI.Presentation.Validations;

namespace DistributorAPI.Infrastructure.Injections;

public static class ProductInjection
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        services.AddScoped<RegisterProductValidationFilter>();
        services.AddScoped<UpdateProductValidationFilter>();
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<RegisterProductHandler>();
        services.AddScoped<UpdateProductHandler>();
        services.AddScoped<DeleteProductHandler>();
        services.AddScoped<GetProductHandler>();
        return services;
    }
}
