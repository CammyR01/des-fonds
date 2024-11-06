namespace des_fonds.Users;

public class Address
{
    private string street;
    private string postCode;
    private string city;
    private string country;


    public string Street { get => street; set => street = value; }
    public string PostCode { get => postCode; set => postCode = value; }
    public string City { get => city; set => city = value; }

    public string Country{get => country; set => country = value; }

    public Address(string street,string postCode, string city, string country)
    {
        this.street = street;
        this.postCode = postCode;
        this.city = city;
        this.country = country;


    }
    public override string ToString()
    {
        return $"Street Address: {Street}\nCity: {City}\nPostcode: {PostCode}\nCountry: {Country}";
    }

}
