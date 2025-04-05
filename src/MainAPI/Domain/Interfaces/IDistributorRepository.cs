using MainAPI.Domain.Entities;

namespace MainAPI.Domain.Interfaces;

public interface IDistributorRepository
{
    Task<Distributor> AddAsync(Distributor distributor);
    Task<Distributor?> GetByCnpjAsync(string cnpj);
}