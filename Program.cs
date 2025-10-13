class Program
{
    static void Main()
    {
        AddressBook addressBook = new AddressBook();
        bool isProgramRunning = true;

        Console.Clear();
        Console.WriteLine("=== Adressboken ===\n");

        while (isProgramRunning)
        {
            Console.WriteLine("--- MENY ---\n");
            Console.WriteLine("(1) Lägg till kontakt\n(2) Uppdatera kontakt\n(3) Radera kontakt\n(4) Sök kontakt\n(5) Visa kontaktlistan\n(6) Avsluta adressboken\n");

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

                case "5":
                    addressBook.ViewContactList();
                    break;

                case "6":
                    Console.Clear();
                    isProgramRunning = false;
                    break;

                default:
                    Console.WriteLine("\nFel inmatning! Tryck på valfri tangent för att återgå till huvudmenyn");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}
