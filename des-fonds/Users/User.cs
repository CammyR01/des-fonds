namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;

    public string Upass { get => uPass; set => uPass = value; }
    public string Uname { get => uName; set => uName = value; }
    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
    }

    

    

}

