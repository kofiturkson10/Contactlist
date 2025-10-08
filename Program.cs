class Program
{
    static void Main()
    {
        bool isProgramRunning = true;

        while (isProgramRunning)
        {
            AddressBook addressBook = new AddressBook();

            Console.WriteLine("=== Adressboken ===");
            Console.WriteLine("\n   MENY   ");
            Console.WriteLine(
                "Gör ett val:\n(1) Lägg till kontakt\n(2) Uppdatera kontakt\n(3) Radera kontakt\n(4) Sök kontakt\n(5) Stäng adressboken"
            );

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
                    Console.Clear();
                    Console.WriteLine("Programmet avslutat");
                    isProgramRunning = false;
                    break;
                default:
                    Console.WriteLine("Fel inmatning!");
                    break;
            }
        }
    }
}
