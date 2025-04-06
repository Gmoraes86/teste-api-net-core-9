using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.CustomerUseCases;

public class GetCustomerHandler(ICustomerRepository customerRepository)
{
    public async Task<List<Customer>> GetAllAsync()
    {
        return await customerRepository.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await customerRepository.GetByIdAsync(id);
    }

    public async Task<Customer?> GetByCnpjAsync(string document)
    {
        return await customerRepository.GetByDocumentAsync(document);
    }
}