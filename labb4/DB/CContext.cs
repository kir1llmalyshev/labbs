using Microsoft.EntityFrameworkCore;

namespace labb4.DB;

public class CContext:DbContext
{
    public DbSet<ContactDto>? Contacts { get; set; }
    
    public CContext(DbContextOptions<CContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
