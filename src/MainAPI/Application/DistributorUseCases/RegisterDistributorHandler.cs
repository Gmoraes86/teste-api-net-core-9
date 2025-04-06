using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

namespace MainAPI.Application.DistributorUseCases;

public class RegisterDistributorHandler(IDistributorRepository distributorRepository)
{
    public async Task<Distributor> Handle(Distributor distributor)
    {
        var existingDistributor = await distributorRepository.GetByCnpjAsync(distributor.Cnpj);
        if (existingDistributor != null)
            throw new InvalidOperationException("A distributor with this CNPJ already exists.");

        return await distributorRepository.AddAsync(distributor);
    }
}