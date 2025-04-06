using DistributorAPI.Domain.Entities;
using DistributorAPI.Domain.Interfaces;
using DistributorAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributorAPI.Infrastructure.Repositories;

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

    public async Task<List<Address>> GetByCustomerIdAsync(Guid customerId)
    {
        return await _context.Addresses
            .Where(da => da.CustomerId == customerId)
            .ToListAsync();
    }
}