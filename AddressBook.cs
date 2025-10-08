using System.ComponentModel.DataAnnotations;
using System.Transactions;

public class AddressBook
{
    private FileHandler fileHandler = new FileHandler();
    private List<Contact> allContacts = new List<Contact>();

    public void AddContact()
    {
        Console.WriteLine("Skriv in namn: ");
        string? inputName = Console.ReadLine(); 

        Console.WriteLine("Skriv in adress: ");
        string? inputAddress = Console.ReadLine();

        Console.WriteLine("Skriv in postnummer: ");
        string? inputZip = Console.ReadLine();

        Console.WriteLine("Skriv in city: ");
        string? inputCity = Console.ReadLine();

        Console.WriteLine("Skriv in telefonnummer: ");
        string? inputPhone = Console.ReadLine();

        Console.WriteLine("Skriv in email: ");  
        string? inputEmail = Console.ReadLine();

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

    public void UpdateContact()
    {
        allContacts = fileHandler.ReadFromFile();

        while (true) {
            Console.WriteLine("\nKontakter i adressboken: ");
            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact.Name.Trim() + " - " + contact.Email.Trim());
            }

            Console.WriteLine("\nVilken kontakt vill du uppdatera? Skriv in den email som tillhör personen annars ange 'exit' för att gå tillbaka till huvudmenyn: ");
            string? inputUser = Console.ReadLine().Trim();

            if (inputUser.ToLower() == "exit") 
            {
                Console.Clear();
                return;
            }

            foreach (var Contact in allContacts)
            {
                string cleanedNameFromContactList = Contact.Email.Trim();

                if (cleanedNameFromContactList == inputUser)
                {
                    Console.WriteLine("Skriv in nytt namn eller enter för att behålla samma: ");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) Contact.Name = newName;

                    Console.WriteLine("Skriv in ny adress eller enter för att behålla samma: ");
                    string? newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress)) Contact.StreetAddress = newAddress;

                    Console.WriteLine("Skriv in nytt postnummer eller enter för att behålla samma: ");
                    string? newZip = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newZip)) Contact.ZipCode = newZip;

                    Console.WriteLine("Skriv in ny city eller enter för att behålla samma: ");
                    string? newCity = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCity)) Contact.City = newCity;

                    Console.WriteLine("Skriv in nytt telefonnummer eller enter för att behålla samma: ");
                    string? newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone)) Contact.PhoneNumber = newPhone;

                    Console.WriteLine("Skriv in ny email eller enter för att behålla samma: ");
                    string? newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail)) Contact.Email = newEmail;

                    Console.WriteLine("Uppdatering klar!");
                    fileHandler.SaveAllContacts(allContacts);
                    return;
                }
            }
            Console.WriteLine("Kontakt hittades inte.");
        }
    }
    public void DeleteContact()
    {
        allContacts = fileHandler.ReadFromFile();

        Console.WriteLine("Skriv in namnet på den kontakt du vill radera: ");
        string? contactToDelete = Console.ReadLine();

        List<Contact> contactsToDelete = allContacts
            .Where(c => c.Name.Contains(contactToDelete, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (contactsToDelete.Count == 0)
            Console.WriteLine("Ingen kontakt hittades med det namnet.");

        foreach (Contact contact in contactsToDelete)
        {
            allContacts.Remove(contact);
        }
        fileHandler.SaveAllContacts(allContacts);
        Console.WriteLine($"Tog bort {contactsToDelete.Count} kontakt(er) från listan.");
    }
    public void SearchContact()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine("=== Sök kontakt ===\n");

            Console.WriteLine("Välj ett alternativ: (1) Sök på namn. (2) Sök på ort. (3) Tillbaka till huvudmenyn. ");

            string searchChoise = Console.ReadLine() ?? "";

            if (searchChoise == "3")
            {
                Console.Clear();
                return;
            }
            if (searchChoise != "1" && searchChoise != "2")
            {
                Console.WriteLine("Ogiltigt val! Försök igen.\n");
                continue;
            }

            if (searchChoise == "1")
            {
                Console.WriteLine("Ange namn: ");
                string searchName = Console.ReadLine() ?? "";

                Console.Clear();

                allContacts = fileHandler.ReadFromFile();
  
                bool match = false;

                foreach (Contact contact in allContacts) 
                {
                    if (contact.Name.ToLower().Contains(searchName.ToLower())) 
                    {
                        if (!match)
                        {
                            Console.WriteLine("\nResultat av sökning:\n");
                            match = true;
                        }
                        Console.WriteLine($"{contact}\n");
                    }
                }

                if (!match)
                {
                    Console.WriteLine("Ingen kontakt hittades! ");
                } 
            }
            else if (searchChoise == "2")
            {
                Console.WriteLine("Ange ort: ");
                string searchCity = Console.ReadLine() ?? "";

                Console.Clear();

                allContacts = fileHandler.ReadFromFile();

                bool match = false;

                foreach (Contact contact in allContacts)
                {
                    if (contact.City.ToLower().Contains(searchCity.ToLower()))
                    {
                        if (!match)
                        {
                            Console.WriteLine("\nResultat av sökning:\n");
                            match = true;
                        }
                        Console.WriteLine($"{contact}\n");
                    }
                }

                if (!match)
                {
                    Console.WriteLine("Ingen kontakt hittades! ");
                } 
            }
            Console.WriteLine("Tryck på valfri knapp för att gå tillbaka till sök menyn. ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
