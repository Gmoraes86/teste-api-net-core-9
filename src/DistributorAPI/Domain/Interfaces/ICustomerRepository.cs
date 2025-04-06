using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer customer);
    Task<Customer?> GetByCnpjAsync(string cnpj);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<Customer> UpdateAsync(Customer customer);
    Task DeleteAsync(Customer customer);
}