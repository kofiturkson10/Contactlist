public class FileHandler
{
    string contactList = @"ContactList.txt";
    public void WriteToFile(string contact)
    {
        using (StreamWriter writer = new StreamWriter(contactList, true))
        {
            writer.WriteLine(contact);
        }
    }
    public void ReadFromFile()
    {
        using (StreamReader reader = new StreamReader(contactList))
        {
            string rad;
            while ((rad = reader.ReadLine()) != null)
            {
                Console.WriteLine(rad);
            }
        }
    }
}