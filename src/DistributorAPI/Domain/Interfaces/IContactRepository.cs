using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface IContactRepository
{
    Task<Contact> AddAsync(Contact contactName);
    Task<List<Contact>> GetByCustomerIdAsync(Guid customerId);
}