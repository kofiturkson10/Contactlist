public class Contact //Måste vara public, annars fungerar inte ReadFromFIle()
{
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(
        string name,
        string streetAddress,
        string zipCode,
        string city,
        string phoneNumber,
        string email
    )
    {
        Name = name;
        StreetAddress = streetAddress;
        ZipCode = zipCode;
        City = city;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public override string ToString() //Här behöver vi ta bort "name", "adress" osv. Endast skriva ut variablarna.
    {
        // return $"Name: {Name}, Address: {StreetAddress}, Zip: {ZipCode} City: {City}, Phone: {PhoneNumber}, Email: {Email}";
        return $"{Name}, {StreetAddress}, {ZipCode}, {City}, {PhoneNumber}, {Email}";
    }
}
