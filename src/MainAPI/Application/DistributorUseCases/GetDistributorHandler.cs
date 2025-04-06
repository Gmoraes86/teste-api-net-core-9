using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

namespace MainAPI.Application.DistributorUseCases;

public class GetDistributorHandler(IDistributorRepository distributorRepository)
{
    public async Task<List<Distributor>> GetAllAsync()
    {
        return await distributorRepository.GetAllAsync();
    }

    public async Task<Distributor?> GetByIdAsync(Guid id)
    {
        return await distributorRepository.GetByIdAsync(id);
    }

    public async Task<Distributor?> GetByCnpjAsync(string cnpj)
    {
        return await distributorRepository.GetByCnpjAsync(cnpj);
    }
}