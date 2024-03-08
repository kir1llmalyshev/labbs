using System.Text.RegularExpressions;

namespace labb2;

public class CController
{
    private readonly List<ContactDto> _contacts;
    private readonly View _view;

    public CController(List<ContactDto> contacts, View view)
    {
        _contacts = contacts;
        _view = view;
    }

    public void AddContact(ContactDto contact) 
    {
        _contacts.Add(contact);
    }
    
    public List<ContactDto> Search(string keyword, int mode)
    {
        var tmp = new List<ContactDto>();
        var regex = new Regex($@"{keyword.ToLower()}(\w*)");
        foreach (var contact in _contacts)
        {
            switch (mode)
            {
                case 1:
                    if (regex.Matches(contact.Name.ToLower()).Count > 0)
                    {
                        tmp.Add(contact);
                    }
                    break;
                case 2:
                    if (regex.Matches(contact.Surname.ToLower()).Count > 0)
                    {
                        tmp.Add(contact);
                    }
                    break;
                case 3:
                    if (regex.Matches(contact.Name.ToLower()).Count > 0 ||
                        regex.Matches(contact.Surname.ToLower()).Count > 0)
                    {
                        tmp.Add(contact);
                    }
                    break;
                case 4:
                    if (regex.Matches(contact.Phone.ToLower()).Count > 0)
                    {
                        tmp.Add(contact);
                    }
                    break;
                case 5:
                    if (regex.Matches(contact.Email.ToLower()).Count > 0)
                    {
                        tmp.Add(contact);
                    }
                    break;
                default:
                    Console.WriteLine("No such contacts.");
                    break;
            }
        }
        return tmp;
    }
    
    public void Run()
    {
        var running = true;
        while (running)
        {
            var menu = _view.ActionQuery();
            switch (menu)
            {
                case 1:
                    _view.ShowAllContacts(_contacts);
                    break;
                case 2:
                    var mode = _view.SearchMode();
                    _view.ShowAllContacts(Search(_view.SearchQuery(), mode));
                    break;
                case 3:
                    AddContact(_view.NewContact());
                    break;
                case 4:
                    running = !running;
                    break;
            }
        }
    }
}