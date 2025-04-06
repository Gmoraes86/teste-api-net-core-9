using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Infrastructure.Repositories;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<Customer> AddAsync(Customer customer)
    {
        context.Customers.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer?> GetByDocumentAsync(string document) // Renomeado de GetByCnpjAsync para GetByDocumentAsync
    {
        return await context.Customers
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .FirstOrDefaultAsync(d => d.Document == document); // Renomeado de Cnpj para Document
    }

    public async Task<List<Customer>> GetAllAsync()
    {
        return await context.Customers
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .ToListAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await context.Customers
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteAsync(Customer customer)
    {
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }
}