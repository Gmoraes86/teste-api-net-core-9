using Microsoft.EntityFrameworkCore;
using MainAPI.Domain.Entities;

namespace MainAPI.Infrastructure;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Distributor> Distributors { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }
}


