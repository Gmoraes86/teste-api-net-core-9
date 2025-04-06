using MainAPI.Domain.Entities;

namespace MainAPI.Domain.Interfaces;

public interface IDistributorRepository
{
    Task<Distributor> AddAsync(Distributor distributor);
    Task<Distributor?> GetByCnpjAsync(string cnpj);
    Task<List<Distributor>> GetAllAsync();
    Task<Distributor?> GetByIdAsync(Guid id);
    Task<Distributor> UpdateAsync(Distributor distributor);
    Task DeleteAsync(Distributor distributor);
}