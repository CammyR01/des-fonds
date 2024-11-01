using System.Reflection.Metadata.Ecma335;

namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;
    private static int id =0;
    private int nextId;
    private Address address;

    public string Upass { get => uPass; set => uPass = value; }
    public string Uname { get => uName; set => uName = value; }
    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
        id = ++nextId;
    }

    public override string ToString()
    {
        string strout = string.Format("Username: {0}\nPassword: {1}", Uname, Upass);
        return strout;
    }

    

    

}

