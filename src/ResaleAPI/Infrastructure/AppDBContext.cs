using Microsoft.EntityFrameworkCore;
namespace ResaleAPI.Infrastructure;


public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}


