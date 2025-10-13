using System.ComponentModel.DataAnnotations;
using System.Transactions;

public class AddressBook
{
    private List<Contact> allContacts = new List<Contact>();
    private FileHandler fileHandler = new FileHandler();
    public void AddContact()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("--- Lägg till kontakt ---\n");

            Console.WriteLine("Skriv in namn: ");
            string? inputName = Console.ReadLine();

            Console.WriteLine("\nSkriv in adress: ");
            string? inputAddress = Console.ReadLine();

            Console.WriteLine("\nSkriv in postnummer: ");
            string? inputZip = Console.ReadLine();

            Console.WriteLine("\nSkriv in city: ");
            string? inputCity = Console.ReadLine();

            Console.WriteLine("\nSkriv in telefonnummer: ");
            string? inputPhone = Console.ReadLine();

            Console.WriteLine("\nSkriv in email: ");
            string? inputEmail = Console.ReadLine();

            Contact contact = new Contact(
                inputName ?? "",
                inputAddress ?? "",
                inputZip ?? "",
                inputCity ?? "",
                inputPhone ?? "",
                inputEmail ?? ""
            );

            fileHandler.WriteToFile(contact);

            Console.WriteLine($"\nKontaken har sparats: {contact}\n");
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn... ");
            Console.ReadKey();
            Console.Clear();
            return;
        }

    }

    public void UpdateContact()
    {

        allContacts = fileHandler.ReadFromFile();
        while (true)
        {
            Console.Clear();

            Console.WriteLine("--- Uppdatera kontakt ---\n");
            Console.WriteLine("Kontakter i adressboken:\n");

            foreach (var contact in allContacts)
            {
                string nameOut = (contact.Name ?? string.Empty).Trim();
                string emailOut = (contact.Email ?? string.Empty).Trim();
                Console.WriteLine($"{nameOut} - {emailOut}");
            }

            Console.WriteLine("\nVilken kontakt vill du uppdatera? Skriv in personens email, annars skriv 'exit' för att gå tillbaka till huvudmenyn:\n");

            string? inputUserRaw = Console.ReadLine();
            string inputUser = (inputUserRaw ?? string.Empty).Trim();

            if (inputUser.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            foreach (var Contact in allContacts)
            {
                string cleanedNameFromContactList = (Contact.Email ?? string.Empty).Trim();

                if (cleanedNameFromContactList.Equals(inputUser, StringComparison.Ordinal))
                {
                    Console.WriteLine("\nSkriv in nytt namn eller enter för att behålla samma: ");
                    string? newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName)) Contact.Name = newName;

                    Console.WriteLine("\nSkriv in ny adress eller enter för att behålla samma: ");
                    string? newAddress = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newAddress)) Contact.StreetAddress = newAddress;

                    Console.WriteLine("\nSkriv in nytt postnummer eller enter för att behålla samma: ");
                    string? newZip = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newZip)) Contact.ZipCode = newZip;

                    Console.WriteLine("\nSkriv in ny city eller enter för att behålla samma: ");
                    string? newCity = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCity)) Contact.City = newCity;

                    Console.WriteLine("\nSkriv in nytt telefonnummer eller enter för att behålla samma: ");
                    string? newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone)) Contact.PhoneNumber = newPhone;

                    Console.WriteLine("\nSkriv in ny email eller enter för att behålla samma: ");
                    string? newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail)) Contact.Email = newEmail;

                    Console.WriteLine("\nUppdatering klar! Tryck på valfri tangent för att åretgå till huvudmenyn");
                    Console.ReadKey();
                    Console.Clear();

                    fileHandler.SaveAllContacts(allContacts);
                    return;
                }
            }
            Console.WriteLine("\nKontakt hittades inte. Tryck på valfri tangent för att skriva igen");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void DeleteContact()
    {
        allContacts = fileHandler.ReadFromFile();

        Console.WriteLine("Skriv in namnet på den kontakt du vill radera: ");
        string? contactToDelete = Console.ReadLine();


        if (string.IsNullOrWhiteSpace(contactToDelete))
        {
            Console.WriteLine("Du måste skriva ett namn.");
            return;
        }

        List<Contact> contactsToDelete = allContacts
            .Where(c => c.Name.Contains(contactToDelete, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (contactsToDelete.Count == 0)
        {
            Console.WriteLine("Ingen kontakt hittades med det namnet.");
            return;
        }

        foreach (Contact contact in contactsToDelete)
        {
            allContacts.Remove(contact);
        }

        fileHandler.SaveAllContacts(allContacts);
        Console.Clear();
        Console.WriteLine($"Tog bort {contactsToDelete.Count} kontakt(er) från listan.");

    }
    public void SearchContact()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("--- Sök kontakt ---\n");
            Console.WriteLine("Välj ett alternativ:\n\n(1) Sök på namn\n(2) Sök på ort\n(3) Återgå till huvudmenyn\n");

            string searchChoise = Console.ReadLine() ?? "";

            if (searchChoise == "3")
            {
                Console.Clear();
                return;
            }
            if (searchChoise != "1" && searchChoise != "2")
            {
                Console.WriteLine("\nOgiltigt val. Tryck på valfri tangent för att återgå till sök menyn.\n");
                Console.ReadKey();
                Console.Clear();
                continue;
            }

            if (searchChoise == "1")
            {
                Console.Clear();

                Console.WriteLine("\nAnge namn:");
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
                    Console.WriteLine("Ingen kontakt hittades!\n");
                }
            }
            else if (searchChoise == "2")
            {
                Console.Clear();

                Console.WriteLine("\nAnge ort:");
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
                    Console.WriteLine("\nIngen kontakt hittades!");
                }
            }
            Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till sök menyn. ");
            Console.ReadKey();
            Console.Clear();
        }
    }
    public void ViewContactList()
    {

        while (true)
        {
            Console.Clear();

            Console.WriteLine("--- Kontakter ---\n");
            Console.WriteLine("Kontakter i adressboken:\n");
            allContacts = fileHandler.ReadFromFile();

            foreach (var contacts in allContacts)
            {
                Console.WriteLine(contacts);
            }

            Console.WriteLine("\nTryck på valfri tangent för att gå tillbaka till huvud menyn. ");
            Console.ReadKey();
            Console.Clear();
            return;
        }
    }
}
