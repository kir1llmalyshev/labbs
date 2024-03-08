using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace labb5.Models;

public class ContactDto : ReactiveObject
{
    [Key]
    public int Id { get; set; }
    
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
}
