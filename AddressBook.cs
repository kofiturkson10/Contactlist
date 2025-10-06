class AddressBook
{
    private FileHandler fileHandler = new FileHandler();
    public List<Contact> allContacts = new List<Contact>(); //Måste vara public, annars fungerar inte ReadFromFIle()

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

    public void UpdateContact() { }

    public string DeleteContact(string name)
    {
// Ta emot något som identifierar vilken kontakt som ska tas bort (t.ex. ett namn eller ett index).
// Ta bort kontakten från listan i minnet.
// Spara den uppdaterade listan till filen igen (så att ändringen inte försvinner när man stänger programmet).
       
     }

    public void SearchContact() { }
}
