using System.Reflection.Metadata.Ecma335;

namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;
    private int id;
    private static int nextId = 0;
    private Address address;

    public string Upass { get => uPass; set => uPass = value; }
    public string Uname { get => uName; set => uName = value; }
    public Address Address { get => address; set => address = value; }

    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
        this.id = ++nextId;
        
    }
    public User(string uName, string uPass,Address address)
    {
        this.uName = uName;
        this.uPass = uPass;
        this.id = ++nextId;

    }

    public User(string streetAddress, string postCode, string city, string country)
    {
        this.uName = uName;
        this.uPass = uPass;
        address = new Address(streetAddress, postCode, city, country);
    }

    public override string ToString()
    {
        string strout = string.Format("User ID: {0}\nUsername: {1}\nPassword: {2}", id, Uname, Upass);
        return strout;
    }







}

