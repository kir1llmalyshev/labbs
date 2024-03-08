using labb4.DB;
using Microsoft.AspNetCore.Mvc;

namespace labb4;

[ApiController]
public class CController : ControllerBase
{
    private readonly IRepo _repo;

    public CController(IRepo repo)
    {
        _repo = repo;
    }

    [HttpPost]
    [Route("/add")]
    public Task Add([FromBody] string fake, string name, string surname, string phone, string email)
    {
        if (name=="" || surname=="" || phone == "" || email=="")
            throw new Exception("Empty fields are not allowed");
        var contact = new ContactDto
        {
            Name = name,
            Surname = surname,
            Phone = phone,
            Email = email
        };
        return _repo.Add(contact);
    }

    [HttpGet]
    [Route("/search")]
    public Task<List<ContactDto>> SearchContact(string keyword, int mode)
    {
        return _repo.Search(keyword, mode);
    }
    
    [HttpGet]
    [Route("/all-contacts")]
    public Task<List<ContactDto>> ViewAllContacts()
    {
        return _repo.ViewAllContacts();
    }
}