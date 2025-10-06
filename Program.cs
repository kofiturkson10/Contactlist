
class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();

        Console.WriteLine("=== Adressboken ===\n");

        Console.WriteLine("Gör ett val: (1) Lägg till kontakt. (2) Uppdatera kontakt. (3) Radera kontakt. (4) Sök kontakt. ");

        string? userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":
                addressBook.AddContact();
                break;

            case "2":
                addressBook.UpdateContact();
                break;

            case "3":
                addressBook.DeleteContact();
                break;

            case "4":
                addressBook.SearchContact();
                break;

            default:
                Console.WriteLine("Fel inmatning!");
                break;
        }
    }
}