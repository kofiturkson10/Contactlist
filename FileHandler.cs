public class FileHandler
{
    string contactList = @"ContactList.txt";

    public void WriteToFile(string contact) //Ändra namn- AddToFile??
    {
        using (StreamWriter writer = new StreamWriter(contactList, true))
        {
            writer.WriteLine(contact);
        }
    }

    // public void ReadFromFile()
    // {
    //     using (StreamReader reader = new StreamReader(contactList))
    //     {
    //         string rad;
    //         while ((rad = reader.ReadLine()) != null)
    //         {
    //             Console.WriteLine(rad);
    //         }
    //     }
    // }

    public List<Contact> ReadFromFile()
    {
        using (StreamReader reader = new StreamReader(contactList))
        {
            List<Contact> allContacts = new List<Contact>();

            if (!File.Exists(contactList))
                return allContacts;

            foreach (var line in File.ReadLines(contactList))
            {
                string[] cDetail = line.Split(',');
                Contact c = new Contact(
                    cDetail[0],
                    cDetail[1],
                    cDetail[2],
                    cDetail[3],
                    cDetail[4],
                    cDetail[5]
                );
                allContacts.Add(c);
            }
            return allContacts;
        }
    }
}


//Lägg till metod OverWriteToFile(); ?
