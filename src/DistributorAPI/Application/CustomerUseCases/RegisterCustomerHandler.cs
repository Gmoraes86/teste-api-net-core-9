using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.CustomerUseCases;

public class RegisterCustomerHandler(ICustomerRepository customerRepository)
{
    public async Task<Customer> Handle(Customer customer)
    {
        var existingCustomer = await customerRepository.GetByDocumentAsync(customer.Document);
        if (existingCustomer != null)
            throw new InvalidOperationException("A customer with this Document already exists.");

        return await customerRepository.AddAsync(customer);
    }
}