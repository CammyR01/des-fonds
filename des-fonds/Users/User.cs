namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;

    public string Upass { get => upass; set => upass = value; }
    public string Uname { get => uname; set => uname = value; }
    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
    }

    

    

}

