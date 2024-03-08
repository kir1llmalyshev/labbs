using Microsoft.EntityFrameworkCore;

namespace labb3.DB;

public class CContext:DbContext
{
    public DbSet<ContactDto>? Contacts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Contacts.db");
    }
}
