using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;

namespace DistributorAPI.Application.CustomerUseCases;

public class UpdateCustomerHandler(ICustomerRepository customerRepository)
{
    public async Task<Customer> Handle(Customer customer)
    {
        var existingCustomer = await customerRepository.GetByIdAsync(customer.Id);
        if (existingCustomer == null)
            throw new InvalidOperationException("Customer not found.");

        existingCustomer.FullName = customer.FullName;
        existingCustomer.TradeName = customer.TradeName;
        existingCustomer.Email = customer.Email;
        existingCustomer.Phone = customer.Phone;

        return await customerRepository.UpdateAsync(existingCustomer);
    }
}