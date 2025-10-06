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
            string cleanedNameFromContactList = Contact.Name.Replace("Name:", "").Trim();

            if (cleanedNameFromContactList == inputName)
            {
                Console.WriteLine("Skriv in nytt namn eller enter för att behålla samma: ");
                string newName = Console.ReadLine();
                if (newName != null && newName != "")
                {
                    Contact.Name = "Name: " + newName + ", ";
                }
                Console.WriteLine("Skriv in ny adress eller enter för att behålla samma: ");
                string newAddress = Console.ReadLine();
                if (newAddress != null && newAddress != "")
                {
                Contact.StreetAddress = "Adress: " + newAddress + ", ";
                }

                Console.WriteLine("Skriv in nytt postnummer eller enter för att behålla samma: ");
                string newZip = Console.ReadLine();
                if (newZip != null && newZip != "")
                {
                    Contact.ZipCode = "Zip: " + newZip + ", ";
                }

                Console.WriteLine("Skriv in ny city eller enter för att behålla samma: ");
                string newCity = Console.ReadLine();
                if (newCity != null && newCity != "")
                {
                    Contact.City = "City: " + newCity + ", ";
                }
                
                Console.WriteLine("Skriv in nytt telefonnummer eller enter för att behålla samma: ");
                string newPhone = Console.ReadLine();
                if (newPhone != null && newPhone != "")
                {
                    Contact.PhoneNumber = "Phone: " + newPhone + ", ";
                }

                Console.WriteLine("Skriv in ny email eller enter för att behålla samma: ");
                string newEmail = Console.ReadLine();
                if (newEmail != null && newEmail != "")
                {
                    Contact.Email = "Email: " + newEmail;
                
                }

                Console.WriteLine("Uppdatering klar!");

                fileHandler.SaveAllContacts(allContacts);
                return;
            }
        }

        Console.WriteLine("Kontakt hittades inte. Avslutar programmet");
    }
    public void DeleteContact()
    {

    }
    public void SearchContact()
    {

    }
}