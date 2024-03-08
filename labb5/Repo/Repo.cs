using System.Collections.Generic;
using System.Linq;
using labb5.DB;
using labb5.Models;

namespace labb5.Repo;

public class Repo:IRepo
{
    private readonly CContext _context;
    
    public Repo(CContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(IEnumerable<ContactDto> contacts)
    {
        _context.Contacts?.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        _context.Contacts?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<ContactDto> LoadFromDb()
    {
        return _context.Contacts!.ToList();
    }
}
