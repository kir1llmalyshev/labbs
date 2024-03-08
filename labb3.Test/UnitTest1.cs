using labb3.DB;
using Moq;

namespace labb3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData("Алблак", "Писятдва", "+7(952)8125252", "alblak@gmail.com", "Алблак")]
    public void SearchTest(string name, string surname, string phone, string email, string keyword)
    {
        var contacts = new List<ContactDto>
        {
            new()
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Email = email
            }
        };
        var myView = new View(); 
        var mock = new Mock<IRepo>();
        mock.Setup(c => c.LoadFromDb()).Returns([]);
        mock.Setup(c => c.LoadFromJson()).Returns([]);
        var myController = new CController(contacts, myView, mock.Object);
        
        Assert.Equal(contacts[0], myController.Search(keyword, 1)[0]);
    }
    
    [Theory]
    [InlineData("Ева", "Тажибаева", "+7(952)8125252", "bruh@gmail.com")]
    public void AddWordTest(string name, string surname, string phone, string email)
    {
        var contacts = new List<ContactDto>();
        var myView = new View();
        var mock = new Mock<IRepo>();
        mock.Setup(c => c.LoadFromDb()).Returns([]);
        mock.Setup(c => c.LoadFromJson()).Returns([]);
        var myController = new CController(contacts, myView, mock.Object);
        var expected = new ContactDto
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email

        };
        myController.AddContact(expected);
        
        Assert.Equal(expected, contacts[0]);
    }
}
