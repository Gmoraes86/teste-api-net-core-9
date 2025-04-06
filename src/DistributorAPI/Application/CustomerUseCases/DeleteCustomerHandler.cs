using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.CustomerUseCases;

public class DeleteCustomerHandler(ICustomerRepository customerRepository)
{
    public async Task Handle(Guid id)
    {
        var customer = await customerRepository.GetByIdAsync(id);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        await customerRepository.DeleteAsync(customer);
    }
}