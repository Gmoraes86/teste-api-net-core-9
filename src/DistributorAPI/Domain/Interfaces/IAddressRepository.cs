using DistributorAPI.Domain.Entities;

namespace DistributorAPI.Domain.Interfaces;

public interface IAddressRepository
{
    Task<Address> AddAsync(Address address);
    Task<List<Address>> GetByCustomerIdAsync(Guid customerId);
}