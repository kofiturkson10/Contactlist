
class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        Console.WriteLine("=== Adressboken ===");
        Console.WriteLine("Lägg till kontakt (1)");
        Console.Write("Uppdatera kontakt (2)");
        Console.Write("Radera kontakt (3)");
        Console.Write("Sök kontakt (4)");

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