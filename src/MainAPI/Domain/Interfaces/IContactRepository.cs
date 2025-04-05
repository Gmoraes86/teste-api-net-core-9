using MainAPI.Domain.Entities;

namespace MainAPI.Domain.Interfaces;

public interface IContactRepository
{
    Task<Contact> AddAsync(Contact contactName);
    Task<List<Contact>> GetByDistributorIdAsync(int distributorId);
}