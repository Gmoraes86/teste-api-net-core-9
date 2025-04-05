using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MainAPI.Infrastructure.Repositories;

public class DistributorRepository : IDistributorRepository
{
    private readonly AppDbContext _context;

    public DistributorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Distributor> AddAsync(Distributor distributor)
    {
        _context.Distributors.Add(distributor);
        await _context.SaveChangesAsync();
        return distributor;
    }

    public async Task<Distributor?> GetByCnpjAsync(string cnpj)
    {
        return await _context.Distributors
            .Include(d => d.Contacts)
            .Include(d => d.Addresses)
            .FirstOrDefaultAsync(d => d.Cnpj == cnpj);
    }
}