using labb3;
using labb3.DB;

var contacts = new List<ContactDto>();
var view = new View();
var repo = new Repo();
var controller = new CController(contacts, view, repo);
controller.Run();
