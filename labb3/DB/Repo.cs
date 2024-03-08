using Newtonsoft.Json;

namespace labb3.DB;

public class Repo:IRepo
{
    private readonly string _path =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contacts.json");

    private readonly CContext _context = new ();

    public Repo()
    {
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(IEnumerable<ContactDto> contacts)
    {
        _context.Contacts?.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Contacts?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<ContactDto> LoadFromDb()
    {
        return _context.Contacts!.ToList();
    }

    public void SaveToJson(List<ContactDto> contacts)
    {
        var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
        File.WriteAllText(_path, jsonData);
    }

    public List<ContactDto> LoadFromJson()
    {
        File.Create(_path).Close();

        var jsonData = File.ReadAllText(_path);
        var data = JsonConvert.DeserializeObject<List<ContactDto>>(jsonData) ?? [];

        return data.Select(contact => new ContactDto { Name = contact.Name, Surname = contact.Surname, Phone = contact.Phone, Email = contact.Email }).ToList();
    }
}