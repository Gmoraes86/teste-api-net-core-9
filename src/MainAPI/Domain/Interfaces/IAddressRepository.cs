using MainAPI.Domain.Entities;

namespace MainAPI.Domain.Interfaces;

public interface IAddressRepository
{
    Task<Address> AddAsync(Address address);
    Task<List<Address>> GetByDistributorIdAsync(int distributorId);
}