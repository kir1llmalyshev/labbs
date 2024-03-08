namespace labb4.DB;

public interface IRepo
{
    Task Add(ContactDto contact);
    Task<List<ContactDto>> Search(string keyword, int mode);
    Task<List<ContactDto>> ViewAllContacts();
}