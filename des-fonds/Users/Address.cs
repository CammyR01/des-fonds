namespace des_fonds.Users;

public class Address

{
 private string streetAddress;
 private string postCode;
 private string city;
 private string country;


 public string streetAddress{get => streetAddress; set => streetAddress = value; }

 public string postCode{get => postCode; set => postCode = value; }

 public string city{get => city; set => city = value; }

 public string country{get => country; set => country = value; }

 public Address(string streetAddress,string postCode, string city, string country)

{
this.streetAddress = streetAddress;
this.postCode = postCode;
this.city = city;
this.country = country;


}


}
