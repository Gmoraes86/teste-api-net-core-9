using MainAPI.Domain.Interfaces;

namespace MainAPI.Application.DistributorUseCases;

public class DeleteDistributorHandler(IDistributorRepository distributorRepository)
{
    public async Task Handle(Guid id)
    {
        var distributor = await distributorRepository.GetByIdAsync(id);
        if (distributor == null)
            throw new InvalidOperationException("Distributor not found.");

        await distributorRepository.DeleteAsync(distributor);
    }
}