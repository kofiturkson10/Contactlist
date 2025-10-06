class AddressBook
{
    private FileHandler fileHandler = new FileHandler();
    public List<Contact> allContacts = new List<Contact>(); //Måste vara public, annars fungerar inte ReadFromFIle()

    public void AddContact()
    {
        Console.WriteLine("Skriv in namn: ");
        string inputName = Console.ReadLine();

        Console.WriteLine("Skriv in adress: ");
        string inputAddress = Console.ReadLine();

        Console.WriteLine("Skriv in postnummer: ");
        string inputZip = Console.ReadLine();

        Console.WriteLine("Skriv in city: ");
        string inputCity = Console.ReadLine();

        Console.WriteLine("Skriv in telefonnummer: ");
        string inputPhone = Console.ReadLine();

        Console.WriteLine("Skriv in email: ");
        string inputEmail = Console.ReadLine();

        Contact contact = new Contact(
            inputName,
            inputAddress,
            inputZip,
            inputCity,
            inputPhone,
            inputEmail
        );
        Console.WriteLine(contact);
        fileHandler.WriteToFile(contact.ToString());
    }

    public void UpdateContact() { }

    public void DeleteContact()
    {
        allContacts = fileHandler.ReadFromFile();

        Console.WriteLine("Skriv in namnet på den kontakt du vill radera: ");
        string contactToDelete = Console.ReadLine();

        var contactsToDelete = allContacts
            .Where(c => c.Name.Contains(contactToDelete, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (contactsToDelete.Count == 0)
            Console.WriteLine("Ingen kontakt hittades med det namnet.");

        foreach (var contact in contactsToDelete)
        {
            allContacts.Remove(contact);
        }

        
    }

    public void SearchContact() { }
}
