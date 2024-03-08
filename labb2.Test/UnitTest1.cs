namespace labb2.Test;

public class UnitTest1
{
    [Fact]
    public void SearchTest()
    {
        var contacts = new List<ContactDto>
        {
            new()
            {
                Name = "Иван",
                Surname = "Дрёмин",
                Phone = "+7999999999",
                Email = "bfuiebaifu@gmail.com"
            },
            new()
            {
                Name = "Алексей",
                Surname = "Йцукен",
                Phone = "+8248924824",
                Email = "gneosngioen@gmail.com"
            }
        };
        var view = new View();
        var controller = new CController(contacts, view);
        var actual = controller.Search("йцу", 3);
        Assert.Equal(actual[0], contacts[1]); 
    }
    
    [Theory]
    [InlineData ("Иван", "Дрёмин", "+7999999999", "bfuiebaifu@gmail.com")]
    public void AddContactTest(string name, string surname, string phone, string email)
    {
        var contact = new ContactDto
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email
        };

        var contacts = new List<ContactDto>();
        var view = new View();
        var controller = new CController(contacts, view);
        controller.AddContact(contact);
        Assert.Equal(contacts[0], contact);
    }
}
