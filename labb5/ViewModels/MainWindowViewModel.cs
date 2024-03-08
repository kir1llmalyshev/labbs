using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DynamicData;
using labb5.DB;
using labb5.Models;
using labb5.Repo;
using ReactiveUI;

namespace labb5.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IRepo _repo;
    
    public MainWindowViewModel()
    {
        var context = new CContext();
        _repo = new Repo.Repo(context);
        var t = _repo.LoadFromDb();
        ContactList.AddRange(t);
        ContactList = new ObservableCollection<ContactDto>(_repo.LoadFromDb());
    }

    private string _name;
    public string Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    
    private string _surname;
    public string Surname
    {
        get => _surname;
        set => this.RaiseAndSetIfChanged(ref _surname, value);
    }
    
    private string _phone;
    public string Phone
    {
        get => _phone;
        set => this.RaiseAndSetIfChanged(ref _phone, value);
    }
    
    private string _email;
    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }
    
    
    private ContactDto _selectedItem;
    public ContactDto SelectedItem
    {
        get => _selectedItem;
        set
        {
            this.RaiseAndSetIfChanged(ref _selectedItem, value);
            if (value != null)
            {
                Name = SelectedItem.Name;
                Surname = SelectedItem.Surname;
                Email = SelectedItem.Email;
                Phone = SelectedItem.Phone;
            }
        }
    }

    
    public ObservableCollection<ContactDto> ContactList { get; set; } = [];
    
    

    public async Task AddContact()
    {
        await Task.Delay(1000);

        Name = "";
        Surname = "";
        Phone = "";
        Email = "";
        SelectedItem = null;
    }
    
    
    public async void SaveChanges()
    {
        await Task.Delay(1000);
        if (SelectedItem == null)
        {
            var newContact = new ContactDto
            {
                Name = Name,
                Surname =Surname,
                Phone = Phone,
                Email = Email
            };
            ContactList.Add(newContact);
        }
        else
        {
            foreach (var contact in ContactList)
            {
                if (contact.Phone == SelectedItem.Phone)
                {
                    contact.Name = Name;
                    contact.Surname = Surname;
                    contact.Phone = Phone;
                    contact.Email = Email;
                    
                }
            }
        }
        _repo.SaveToDb(ContactList);

    }
}
