using des_fonds.Finances;
using System.Reflection.Metadata.Ecma335;

namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;
    private int id;
    private static int nextId = 0;
    private Address address;
    private List<Statement> statements;

    public string Upass { get => uPass; set => uPass = value; }
    public string Uname { get => uName; set => uName = value; }
    public Address Address { get => address; set => address = value; }
    public List<Statement> Statements { get => statements; set => statements = value; }

    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
        this.id = ++nextId;
        statements = new List<Statement>();

    }
    public User(string uName, string uPass, Address address)
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

    public void AddStatement(Statement statement)
    {
        statements.Add(statement);
    }

    public override string ToString()
    {
        string strout = string.Format("User ID: {0}\nUsername: {1}\nPassword: {2}", id, Uname, Upass);
        return strout;
    }





}

