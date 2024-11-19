using des_fonds.Finances;
using des_fonds.Mail;

namespace des_fonds.Users;

public class User
{
    private string uName;
    private string uPass;
    private string firstName;
    private string lastName;
    private int age;
    
    private int id;
    private static int nextId = 0;
    private Address address;
    private List<Statement> statements;

    private Household? household;
    private bool isHeadOfHouse;
    private List<Message> messages;
    private bool newNotification;
    private int notificationCount;

    public string Upass { get => uPass; set => uPass = value; }
    public string Uname { get => uName; set => uName = value; }
    public Address Address { get => address; set => address = value; }
    public List<Statement> Statements { get => statements; set => statements = value; }
    public List<Message> Messages { get => messages; set => messages = value; }
    public bool NewNotification { get => newNotification; set => newNotification = value; }
    public int NotificationCount { get => notificationCount; set => notificationCount = value; }
    public bool IsHeadOfHouse { get => isHeadOfHouse; set => isHeadOfHouse = value; }
    public Household? Household { get => household; set => household = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public int Age { get => age; set => age = value; }

    public User(string uName, string uPass)
    {
        this.uName = uName;
        this.uPass = uPass;
        this.id = ++nextId;
        statements = new List<Statement>();
        this.isHeadOfHouse = false;
        messages = new List<Message>();
        this.newNotification = false;
        this.notificationCount = 0;
        


    }

    public User(string uname, string upass, string firstname, string lastname, int age, string street, string postcode, string city, string country)
    {
        this.uName = uname;
        this.uPass = upass;
        this.firstName = firstname;
        this.lastName = lastname;
        this.age = age;
        this.id = ++nextId;
        this.IsHeadOfHouse = false;
        statements = new List<Statement>();
        messages = new List<Message>();
        this.newNotification = false;
        this.notificationCount = 0;
        this.address = new Address(street, postcode, city, country);
    }
    //public User(string uName, string uPass, string streetAddress, string postCode, string city, string country)
    //{
    //    this.uName = uName;
    //    this.uPass = uPass;
    //    this.id = ++nextId;
    //    statements = new List<Statement>();
    //    this.address = new Address(streetAddress, postCode, city, country);
    //    this.isHeadOfHouse = false;
    //    messages = new List<Message>();
    //    this.newNotification = false;
    //    this.notificationCount = 0;

    //}


    public void AddStatement(Statement statement)
    {
        statements.Add(statement);
    }
    
    public string BasicInfo()
    {
        string info = string.Format($"Username: {uName}\nFirst Name: {firstName}\nLast Name: {lastName}\nAge: {age}");
        return info;
    }

    public override string ToString()
    {
        string strout = string.Format("User ID: {0}\nUsername: {1}\nFirst name: {2}\n Last name: {3}", id, Uname, firstName, lastName);
        strout += "\n" + address;
        return strout;
    }
    public void CreateHousehold()
    {
        //check if user is in a household
        if (isHeadOfHouse)
        {
            throw new Exception("Already in a household!");
        }
        else
        {
            this.household = new Household(this);
            this.isHeadOfHouse = true;

        }
    }


}


