class FileHandler
{
    string contactList = @"ContactList.txt";

    public void WriteToFile(Contact contact)
    {
        using (StreamWriter writer = new StreamWriter(contactList, true))
        {
            writer.WriteLine(contact.ToString());
        }
    }

    public List<Contact> ReadFromFile()
    {
        List<Contact> allContacts = new List<Contact>();

        if (!File.Exists(contactList)) 
            return allContacts;

        foreach (var line in File.ReadLines(contactList))
        {
            if (string.IsNullOrWhiteSpace(line)) 
                continue;

            string[] cDetail = line.Split(',', StringSplitOptions.TrimEntries);
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

    public void SaveAllContacts(List<Contact> contacts)
    {
        using (StreamWriter writer = new StreamWriter(contactList))
        {
            foreach (Contact c in contacts)
                writer.WriteLine(
                   c.ToString()
                );
        }
    }
}
