
class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        Console.WriteLine("=== Adressboken ===");
        Console.WriteLine("Gör ett val: (1) Lägg till kontakt (2) Uppdatera kontakt (3) Radera kontakt (4) Sök kontakt");

        string? userChoice = Console.ReadLine();

        if (userChoice == "1")
        {
            addressBook.AddContact();
        }
        else if (userChoice == "2")
        {
            addressBook.UpdateContact();
        }
        else if (userChoice == "3")
        {
            addressBook.DeleteContact();
        }
        else if (userChoice == "4")
        {
            addressBook.SearchContact();
        }
        else
        {
            Console.WriteLine("Fel inmatning!");
        }
    }
}