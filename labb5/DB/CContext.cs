using labb5.Models;
using Microsoft.EntityFrameworkCore;

namespace labb5.DB;

public class CContext: DbContext
{
    public DbSet<ContactDto>? Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Contacts.db");
    }
}
