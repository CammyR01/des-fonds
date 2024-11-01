namespace des_fonds.Users;

public class Address

{
 private string streetAddress;
 private string postCode;
 private string city;



 public Address(string streetAddress,string postCode, string city)

{
this.streetAddress = streetAddress;
this.postCode = postCode;
this.city = city;


}

    public string StreetAddress { get => streetAddress; set => streetAddress = value; }
    public string PostCode { get => postCode; set => postCode = value; }
    public string City { get => city; set => city = value; }
}
