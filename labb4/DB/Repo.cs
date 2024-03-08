using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace labb4.DB;

public class Repo:IRepo
{
    private readonly CContext _context;

    public Repo(CContext context)
    {
        _context = context;
    }
    
    public Task Add(ContactDto contact)
    {
        if (_context.Contacts!.Any(c => c.Name == contact.Name && c.Surname == contact.Surname && c.Phone ==
                contact.Phone && c.Email == contact.Email)) throw new Exception("Contact already exists.");
        _context.Contacts?.Add(contact);
        return _context.SaveChangesAsync();

    }
    
    public async Task<List<ContactDto>> Search(string keyword, int mode) // Реализация поиска по ключевым словам
    {
        var allContacts = await _context.Contacts!.ToListAsync();

        var regex = new Regex($@"{keyword.ToLower()}(\w*)", RegexOptions.IgnoreCase);

        switch (mode)
        {
            case 1:
                return allContacts
                    .Where(c => regex.IsMatch(c.Name.ToLower()))
                    .ToList();
            case 2:
                var surnameRegex = new Regex($@"{keyword.ToLower()}(\w*)", RegexOptions.IgnoreCase);
                return allContacts
                    .Where(c => surnameRegex.IsMatch(c.Surname.ToLower()))
                    .ToList();
            case 3:
                return allContacts
                    .Where(c => regex.IsMatch(c.Name.ToLower()) || regex.IsMatch(c.Surname.ToLower()))
                    .ToList();
            case 4:
                var phoneRegex = new Regex($@"{keyword.ToLower()}(\w*)", RegexOptions.IgnoreCase);
                return allContacts
                    .Where(c => phoneRegex.IsMatch(c.Phone.ToLower()))
                    .ToList();
            case 5:
                var emailRegex = new Regex($@"{keyword.ToLower()}(\w*)", RegexOptions.IgnoreCase);
                return allContacts
                    .Where(c => emailRegex.IsMatch(c.Email.ToLower()))
                    .ToList();
            default:
                throw new Exception("Unknown mode or contact not found.");
        }
    }
    
    public async Task<List<ContactDto>> ViewAllContacts()
    {
        return await _context.Contacts!.ToListAsync();
    }
}