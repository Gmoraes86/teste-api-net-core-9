using MainAPI.Domain.Entities;
using MainAPI.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MainAPI.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _context;

    public ContactRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Contact> AddAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<List<Contact>> GetByDistributorIdAsync(int distributorId)
    {
        return await _context.Contacts
            .Where(cn => cn.DistributorId == distributorId)
            .ToListAsync();
    }
}