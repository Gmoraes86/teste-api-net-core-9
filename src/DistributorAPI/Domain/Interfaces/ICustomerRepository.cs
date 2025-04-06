using DistributorAPI.Domain.Entities;


namespace DistributorAPI.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer> AddAsync(Customer distributor);
    Task<Customer?> GetByDocumentAsync(string document);
    Task<List<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(Guid id);
    Task<Customer> UpdateAsync(Customer distributor);
    Task DeleteAsync(Customer distributor);
}