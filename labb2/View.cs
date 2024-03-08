namespace labb2;

public class View
{
    public int ActionQuery()
    {
        Console.WriteLine("\nMenu:\n1. View all contacts\n2. Search\n3. New contact\n4. Exit\n");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 4)
            throw new Exception("Invalid value.");
        return n;
    }
    
    public ContactDto NewContact()
    {
        var contact = new ContactDto();

        Console.WriteLine("New contact");
        Console.Write("Name: ");
        contact.Name = Console.ReadLine() ?? "";

        Console.Write("Surname: ");
        contact.Surname = Console.ReadLine() ?? "";

        Console.Write("Phone: ");
        contact.Phone = Console.ReadLine() ?? "";

        Console.Write("E-mail: ");
        contact.Email = Console.ReadLine() ?? "";
        
        return contact;
    }
    
    public void ShowAllContacts(List<ContactDto> contacts)
    {
        var count = contacts.Count;
        if (count > 0)
        {
            Console.WriteLine($"Results ({count}):");
            for (var i = 0; i < count; i++)
            {
                Console.WriteLine("#" + i);
                Console.WriteLine("Name: " + contacts[i].Name);
                Console.WriteLine("Surname: " + contacts[i].Surname);
                Console.WriteLine("Phone: " + contacts[i].Phone);
                Console.WriteLine("E-mail: " + contacts[i].Email);
            }
        }
        else
            Console.WriteLine("No such contacts.");
    }
    
    public string SearchQuery()
    {
        Console.Write("Request: ");
        var input = Console.ReadLine() ?? "";
        return input;
    }
    
    public int SearchMode() // Взаимодействие с пользователем для выбора пунктов меню
    {
        Console.WriteLine(
            "Search by:\n1. Name.\n2. Surname.\n3. Name and surname.\n4. Phone.\n5. E-mail.");
        Console.Write("> ");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 5)
            throw new Exception("Invalid value");
        return n;
    }
}