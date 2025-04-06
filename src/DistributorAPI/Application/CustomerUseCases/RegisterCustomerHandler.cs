using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.CustomerUseCases;

public class RegisterCustomerHandler(ICustomerRepository customerRepository)
{
    public async Task<Customer> Handle(Customer customer)
    {
        var existingCustomer = await customerRepository.GetByCnpjAsync(customer.Cnpj);
        if (existingCustomer != null)
            throw new InvalidOperationException("A customer with this CNPJ already exists.");

        return await customerRepository.AddAsync(customer);
    }
}