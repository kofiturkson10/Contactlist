using System.ComponentModel.DataAnnotations;

class AddressBook
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
        int i = 0; // Lägg till räknare för att hantarea dubeltter?

        Console.WriteLine("Kontakter i adressboken: ");
        foreach (var contact in allContacts) 
        {
            i++;
            Console.WriteLine(i + "Namn: " + contact.Name.Trim() + "Email: " + contact.Email.Trim());
        }

        Console.WriteLine("Vilken kontakt vill du uppdatera? Skriv in numret: ");
        string? inputName = Console.ReadLine().Trim();

        foreach (var Contact in allContacts)
        {
            string cleanedNameFromContactList = Contact.Name.Trim();

            if (cleanedNameFromContactList == inputName)
            {
                Console.WriteLine("Skriv in nytt namn eller enter för att behålla samma: ");
                string? newName = Console.ReadLine();
                if (newName != null && newName != "") Contact.Name = newName; // VS string.IsNullOrWhiteSpace(newName)

                Console.WriteLine("Skriv in ny adress eller enter för att behålla samma: ");
                string? newAddress = Console.ReadLine();
                if (newAddress != null && newAddress != "") Contact.StreetAddress = newAddress;

                Console.WriteLine("Skriv in nytt postnummer eller enter för att behålla samma: ");
                string? newZip = Console.ReadLine();
                if (newZip != null && newZip != "") Contact.ZipCode = newZip;

                Console.WriteLine("Skriv in ny city eller enter för att behålla samma: ");
                string? newCity = Console.ReadLine();
                if (newCity != null && newCity != "") Contact.City = newCity;
                
                Console.WriteLine("Skriv in nytt telefonnummer eller enter för att behålla samma: ");
                string? newPhone = Console.ReadLine();
                if (newPhone != null && newPhone != "") Contact.PhoneNumber = newPhone;

                Console.WriteLine("Skriv in ny email eller enter för att behålla samma: ");
                string? newEmail = Console.ReadLine();
                if (newEmail != null && newEmail != "") Contact.Email = newEmail;

                Console.WriteLine("Uppdatering klar!");
                fileHandler.SaveAllContacts(allContacts);
                return;
            }
        }
        Console.WriteLine("Kontakt hittades inte. Avslutar programmet");
    }
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
            fileHandler.SaveAllContacts(allContacts);
            Console.WriteLine($"Tog bort {contactsToDelete.Count} kontakt(er) från listan.");

        }
    }

    public void SearchContact()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine("=== Sök kontakt ===\n");

            Console.WriteLine("Välj ett alternativ: (1) Sök på namn. (2) Sök på postort. (3) Tillbaka till huvudmenyn. ");
            string searchChoise = Console.ReadLine() ?? "";

            if (searchChoise == "3")
            {
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

                string[] contacts = File.ReadAllLines("ContactList.txt");
                bool match = false;

                foreach (string contact in contacts)
                {
                    if (contact.ToLower().Contains(searchName.ToLower()))
                    {
                        Console.WriteLine($"\n{contact}\n");
                        match = true;
                    }
                }
                if (!match)
                {
                    Console.WriteLine("Ingen kontakt hittades! ");
                }
            }
            else if (searchChoise == "2")
            {
                Console.WriteLine("Ange postort: ");
                string searchCity = Console.ReadLine() ?? "";

                string[] contacts = File.ReadAllLines("ContactList.txt");
                bool match = false;

                foreach (string contact in contacts)
                {
                    if (contact.ToLower().Contains(searchCity.ToLower()))
                    {
                        Console.WriteLine(contact);
                        match = true;
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
