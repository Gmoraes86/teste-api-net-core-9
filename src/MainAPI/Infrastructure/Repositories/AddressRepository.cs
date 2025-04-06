using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;
using MainAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MainAPI.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly AppDbContext _context;

    public AddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Address> AddAsync(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<List<Address>> GetByDistributorIdAsync(Guid distributorId)
    {
        return await _context.Addresses
            .Where(da => da.DistributorId == distributorId)
            .ToListAsync();
    }  
}