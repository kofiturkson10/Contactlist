using System.ComponentModel.DataAnnotations;

class AddressBook
{
    private FileHandler fileHandler = new FileHandler();
    public List<Contact> allContacts = new List<Contact>();
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
        allContacts = fileHandler.ReadFromFile();

        Console.WriteLine("Kontakter i adressboken: ");
        foreach (var contact in allContacts)
        {
            Console.WriteLine(contact.Name.Replace("Name:", "").Trim());

        }
        Console.WriteLine("Vilken kontakt vill du uppdatera? Skriv in namn: ");
        string inputName = Console.ReadLine().Trim();

        foreach (var Contact in allContacts)
        {
            if (Contact.Name.Substring(5).Trim() == inputName)
            {
                Console.WriteLine("Skriv in nytt namn: ");
                string newName = Console.ReadLine();
                Contact.Name = newName;

                Console.WriteLine("Skriv in ny adress: ");
                string newAddress = Console.ReadLine();
                Contact.StreetAddress = newAddress;

                Console.WriteLine("Skriv in nytt postnummer: ");
                string newZip = Console.ReadLine();
                Contact.ZipCode = newZip;

                Console.WriteLine("Skriv in ny city: ");
                string newCity = Console.ReadLine();
                Contact.City = newCity;

                Console.WriteLine("Skriv in nytt telefonnummer: ");
                string newPhone = Console.ReadLine();
                Contact.PhoneNumber = newPhone;

                Console.WriteLine("Skriv in ny email: ");
                string newEmail = Console.ReadLine();
                Contact.Email = newEmail;

                fileHandler.SaveAllContacts(allContacts);
            }
        }
    }
    public void DeleteContact()
    {

    }
    public void SearchContact()
    {

    }
}