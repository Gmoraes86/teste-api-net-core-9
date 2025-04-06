using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;
using MainAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Infrastructure.Repositories;

public class DistributorRepository(AppDbContext context) : IDistributorRepository
{
    public async Task<Distributor> AddAsync(Distributor distributor)
    {
        context.Distributors.Add(distributor);
        await context.SaveChangesAsync();
        return distributor;
    }

    public async Task<Distributor?> GetByCnpjAsync(string cnpj)
    {
        return await context.Distributors
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .FirstOrDefaultAsync(d => d.Cnpj == cnpj);
    }

    public async Task<List<Distributor>> GetAllAsync()
    {
        return await context.Distributors
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .ToListAsync();
    }

    public async Task<Distributor?> GetByIdAsync(Guid id)
    {
        return await context.Distributors
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Distributor> UpdateAsync(Distributor distributor)
    {
        context.Distributors.Update(distributor);
        await context.SaveChangesAsync();
        return distributor;
    }

    public async Task DeleteAsync(Distributor distributor)
    {
        context.Distributors.Remove(distributor);
        await context.SaveChangesAsync();
    }
}