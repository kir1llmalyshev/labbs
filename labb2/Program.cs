using labb2;

var contacts = new List<ContactDto>();
var view = new View();
var controller = new CController(contacts, view);
controller.Run();
