class AddressBook
{
    private FileHandler fileHandler = new FileHandler();
    private List<Contact> allContacts = new List<Contact>();
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

        Contact contact = new Contact(inputName, inputAddress, inputZip, inputCity, inputPhone, inputEmail);
        Console.WriteLine(contact);
        fileHandler.WriteToFile(contact.ToString());


    }
    public void UpdateContact()
    {

    }
    public void DeleteContact()
    {

    }
    public void SearchContact()
    {

    }
}