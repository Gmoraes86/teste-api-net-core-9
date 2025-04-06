using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

namespace MainAPI.Application.DistributorUseCases;

public class UpdateDistributorHandler(IDistributorRepository distributorRepository)
{
    public async Task<Distributor> Handle(Distributor distributor)
    {
        var existingDistributor = await distributorRepository.GetByIdAsync(distributor.Id);
        if (existingDistributor == null)
            throw new InvalidOperationException("Distributor not found.");

        existingDistributor.CorporateName = distributor.CorporateName;
        existingDistributor.TradeName = distributor.TradeName;
        existingDistributor.Email = distributor.Email;
        existingDistributor.Phone = distributor.Phone;

        return await distributorRepository.UpdateAsync(existingDistributor);
    }
}