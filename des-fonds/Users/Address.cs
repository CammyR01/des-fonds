namespace des_fonds.Users;

public class Address
{
    private string streetAddress;
    private string postCode;
    private string city;
    private string country;


    public string StreetAddress { get => streetAddress; set => streetAddress = value; }
    public string PostCode { get => postCode; set => postCode = value; }
    public string City { get => city; set => city = value; }

    public string Country{get => country; set => country = value; }

    public Address(string streetAddress,string postCode, string city, string country)
    {
        this.streetAddress = streetAddress;
        this.postCode = postCode;
        this.city = city;
        this.country = country;


    }

}
