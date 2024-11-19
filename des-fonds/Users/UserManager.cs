using des_fonds.Controller;
using des_fonds.encrypt;
using des_fonds.Finances;
using des_fonds.Mail;
namespace des_fonds.Users;

public static class UserManager
{
    //private User user;
    //private Address address;

    //public UserManager()
    //{
    //    //should this be a static class and dont think this is needed it should get all that info from the users class

    //    //also if static you dont need a constructor you can call it directly 
    //    // like UserManager.GetUserDetails(User user) and get attributes with
    //    // user.Uname or Address address = user.Address; i will give you a message later bud
    //    // Default user details

    //    string uName = "Sugar";
    //    string uPass = "Sugar1";

    //    string streetAddress = "808 Kanye West";
    //    string postCode = "TLOP";
    //    string city = "Chicago";
    //    string country = "America";

    //    address = new Address(streetAddress, postCode, city, country);
    //    // Initialise the User and Address
    //    user = new User(uName, uPass, address);
    //}

    /// <summary>
    /// edits users username if its a valid username
    /// </summary>
    /// <param name="user">the user</param>
    /// <param name="newUsername">the new username</param>
    public static void EditUserDetails(User user, string username, string firstname, string lastname)
    {
        try
        {
            //perform validation
            if (isValidUserName(username))
            {
                if (IsValidFirstName(firstname))
                {
                    if (IsValidLastName(lastname))
                    {
                        //username is valid, set new name
                        user.Uname = username;
                        user.FirstName = firstname;
                        user.LastName = lastname;
                        Console.WriteLine("user name updated to :" + user.Uname);
                    }
                }
                
            }

        }
        catch (Exception e)
        {
            //throw not valid message
            Console.WriteLine(e.Message);
        }
    }
    public static string Last5Statements(User user)
    {
        int lengthOfStatements = user.Statements.Count;
        if (lengthOfStatements <= 5)
        {
            string strout = "";
            for(int i = 0; i < lengthOfStatements; i++)
            {
                strout += user.Statements[i].ToString() + "\n";
            }
            return strout;
        }
        else
        {
            string strout = "";
            for(int i = (lengthOfStatements - 5);i < lengthOfStatements; i++)
            {
                strout += user.Statements[i].ToString() + "\n";
            }
            return strout;

        }
        
    }
    public static string Last5Bills(User user)
    {
        int lengthOfBills = user.Bills.Count;
        if (lengthOfBills <= 5)
        {
            string strout = "";
            for (int i = 0; i < lengthOfBills; i++)
            {
                strout += user.Bills[i].ToString() + "\n";
            }
            return strout;
        }
        else
        {
            string strout = "";
            for (int i = (lengthOfBills - 5); i < lengthOfBills; i++)
            {
                strout += user.Bills[i].ToString() + "\n";
            }
            return strout;

        }

    }
    private static bool IsValidDouble(string value)
    {
        try
        {
            Double.Parse(value);
            return true;
        }
        catch
        {
            return false;
        }
    }
    private static bool IsValidDate(string strDate)
    {
        try
        {
            DateTime date = DateTime.Parse(strDate);
            return true;
        }
        catch 
        {
            return false;
        }
    }
    public static void AddIncome(User user, string source, string strAmount, string strDate)
    {
        if (IsStrEmpty(source))
        {
            throw new Exception("Financial name cant be empty");
        }
        else if (IsStrEmpty(strAmount))
        {
            throw new Exception("Amount cant be empty");
        }
        else if (!IsValidDouble(strAmount))
        {
            throw new Exception("amount is not in the correct format");
        }
        else if (IsStrEmpty(strDate))
        {
            throw new Exception("Please select a date");
        }
        else if(!IsValidDate(strDate))
        {
            throw new Exception("Date is not in the correct format");
        }
        else
        {
            double amount = double.Parse(strAmount);
            DateTime date = DateTime.Parse(strDate);
            Income income = new Income(source, amount, date);
            user.AddStatement(income);
        }
        
        
        
        
    }
    public static void AddBill(User user, string billName, string strAmount,Status status, string strdueDate)
    {
        if (IsStrEmpty(billName))
        {
            throw new Exception("Financial name cant be empty");
        }
        else if (IsStrEmpty(strAmount))
        {
            throw new Exception("Amount cant be empty");
        }
        else if (!IsValidDouble(strAmount))
        {
            throw new Exception("amount is not in the correct format");
        }
        else if (IsStrEmpty(strdueDate))
        {
            throw new Exception("Please select a date");
        }
        else if (!IsValidDate(strdueDate))
        {
            throw new Exception("Date is not in the correct format");
        }
        else
        {
            double amount = double.Parse(strAmount);
            DateTime Duedate = DateTime.Parse(strdueDate);
            status = Status.Pending;
            Bill bill = new Bill(billName, status ,amount, Duedate);
            user.AddBill(bill);
        }




    }
    public static void AddExpense(User user, string source, string strAmount, string strDate)
    {
        if (IsStrEmpty(source))
        {
            throw new Exception("Financial name cant be empty");
        }
        else if (IsStrEmpty(strAmount))
        {
            throw new Exception("Amount cant be empty");
        }
        else if (!IsValidDouble(strAmount))
        {
            throw new Exception("amount is not in the correct format");
        }
        else if (IsStrEmpty(strDate))
        {
            throw new Exception("Please select a date");
        }
        else if (!IsValidDate(strDate))
        {
            throw new Exception("Date is not in the correct format");
        }
        else
        {
            double amount = double.Parse(strAmount);
            DateTime date = DateTime.Parse(strDate);
            Expense expense = new Expense(source, amount, date);
            user.AddStatement(expense);
        }




    }
    public static void RemoveUser(User user)
    {
        try
        {
            // Retrieve the user list from the MoneyApp instance
            MoneyApp app = MoneyApp.Instance;

            // Check if the user exists in the list
            if (app.UserList.Contains(user))
            {
                // Remove the user and display confirmation
                app.UserList.Remove(user);
                Console.WriteLine("User removed: " + user.Uname);
            }
            else
            {
                // User not found, throw an exception
                throw new Exception("User not found in the system.");
            }
        }
        catch (Exception e)
        {
            // Print the error message if an exception occurs
            Console.WriteLine(e.Message);
        }
    }

    public static bool isValidUserName(string username)
    {
        //check if string is null or empty
        if (IsStrEmpty(username))
        {
            //is empty
            throw new Exception("Username cant be empty");
        }
        //check if username is 3 or less characters
        else if (username.Length < 3)
        {
            //user name too short
            throw new Exception("username must be longer than 3 characters");
        }
        //validation passed
        return true;

    }

    public static void EditAddress(User user, string newStreet, string newPostcode, string newCity, string newCountry)
    {
        //Validate street
        if (IsStreetValid(newStreet))
        {
            //validate postcode
            if (IsPostcodeValid(newPostcode))
            {
                //validate city
                if (IsCityValid(newCity))
                {
                    //if country is valid
                    if (IsCountryValid(newCountry))
                    {
                        //everything is valid change address
                        Address address = user.Address;
                        address.Street = newStreet;
                        address.PostCode = newPostcode;
                        address.City = newCity;
                        address.Country = newCountry;
                    }//if4
                    else
                    {
                        //country not valid
                        throw new Exception("country is not valid");
                    }
                }//if3
                else
                {
                    //city is not valid
                    throw new Exception("city is not valid");
                }
            }//if2
            else
            {
                //postcode not valid
                throw new Exception("Postcode not valid");
            }
        }//if1
        else
        {
            //street not valid 
            throw new Exception("Street not valid");
        }
    }
    private static bool IsStreetValid(string newStreet)
    {
        //check street is empty
        if (IsStrEmpty(newStreet))
        {
            //street is empty
            throw new Exception("Street cant be empty");
        }
        else if (newStreet.Length < 4)
        {
            //street name too short
            throw new Exception("Street name must be 4 or more characters");
        }
        //passed validation
        return true;
    }

    private static bool IsPostcodeValid(string newPostcode)
    {
        //check if postcode is empty
        if (IsStrEmpty(newPostcode))
        {
            //postcode is empty
            throw new Exception("postcode cant be empty");
        }
        //check postcode is correct length
        else if (newPostcode.Length < 6 && newPostcode.Length > 8)
        {
            //incorrect length
            throw new Exception("postcode must be between 6 and 8");
        }
        //validation passed
        return true;
    }

    private static bool IsCityValid(string newCity)
    {
        // check if city is empty
        if (IsStrEmpty(newCity))
        {
            //city is empty
            throw new Exception("city cant be empty");
        }
        //check if city length is less than 4
        else if (newCity.Length < 4)
        {
            //city too short
            throw new Exception("city must be 4 or more characters");
        }
        //validation passed
        return true;

    }
    private static bool IsCountryValid(string newCountry)
    {
        //check if new country is empty
        if (IsStrEmpty(newCountry))
        {
            //country is empty
            throw new Exception("Country cant be empty");

        }
        //check if country has characters less than 4
        else if (newCountry.Length < 4)
        {
            //country is to short
            throw new Exception("Country to short. must be greater than 4 characters");
        }
        //validation passed
        return true;
    }
    public static User LoginUser(string username, string password)
    {
        MoneyApp app = MoneyApp.Instance;
        foreach (User user in app.UserList)
        {
            if (user.Uname == username)
            {
                //check password
                if (Sha256Hasher.CheckHash(user.Upass, password))
                {
                    return user;
                }
                break;
            }
        }
        throw new Exception("Username or password incorrect");

    }
    private static bool IsStrEmpty(string str)
    {
        //check if string is empty or null
        if (string.IsNullOrEmpty(str))
        {
            //string is empty or null
            return true;
        }
        //string contains characters
        return false;
    }
    private static bool IsValidAge(string strAge)
    {
        if (IsStrEmpty(strAge))
        {
            throw new Exception("Age cant be empty");
        }
        else
        {
            try
            {
                int age = int.Parse(strAge);
                if (age < 16)
                {
                    throw new Exception("You must be 16 or older");
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
    private static bool IsValidFirstName(string name)
    {
        if (IsStrEmpty(name))
        {
            throw new Exception("Name cant be empty");
        }
        else
        {
            if(name.Length < 3)
            {
                throw new Exception($"{name} is not valid");
            }
            else
            {
                return true;
            }
        }
    }
    private static bool IsValidLastName(string name)
    {
        if (IsStrEmpty(name))
        {
            throw new Exception("Name cant be empty");
        }
        else
        {
            if (name.Length < 3)
            {
                throw new Exception($"{name} is not valid");
            }
            else
            {
                return true;
            }
        }
    }

    public static void RegisterUser(string username, string password, string firstname, string lastname, string age, string street, string postcode, string city, string country)
    {
        try
        {
            //Validate registration fields
            if (isValidUserName(username))
                if(IsValidAge(age))
                    if(IsValidFirstName(firstname))
                        if(IsValidLastName(lastname))
                            if (IsStreetValid(street))
                                if (IsPostcodeValid(postcode))
                                    if (IsCityValid(city))
                                        if (IsCountryValid(country))
                                        {
                                            //All validation passed
                                            //hash password
                                            string hashPass = Sha256Hasher.Hash(password);
                                            int age1= Convert.ToInt32(age);
                                            //create user
                                            User user = new User(username, hashPass,firstname,lastname,age1, street, postcode, city, country);
                                            //add user to instace list
                                            MoneyApp.Instance.AddUser(user);
                                            DataController.AddUserEntry(user.Id, user.Uname, hashPass);
                                        }
        }
        catch (Exception ex)
        {
            //a validation failed, print message
            Console.WriteLine(ex.Message);
        }

    }
    public static void SendInvite(User partyA, string username, string message)
    {
        try
        {
            User partyB = GetUserByUsername(username);
            Invite invite = new Invite(DateTime.Now.Date, partyA, partyB, message);
            partyB.Messages.Add(invite);
            partyB.NewNotification = true;
            partyB.NotificationCount += 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void ReturnAcceptInvite(Invite acceptedInvite)
    {
        User partyA = acceptedInvite.PartyA;
        User partyB = acceptedInvite.PartyB;
        partyA.Messages.Add(acceptedInvite);
        partyA.NotificationCount++;
        partyA.NewNotification = true;

        partyB.Address = partyA.Address;
        partyA.Household.Members.Add(acceptedInvite.PartyB);
        
    }
    public static void AcceptInvite(User user, Invite invite)
    {
        invite.Accept();
        
    }
    private static User GetUserByUsername(string username)
    {
        foreach (User u in MoneyApp.Instance.UserList)
        {
            if (u.Uname == username)
            {
                return u;
            }
        }
        throw new Exception("User not found");
    }
            
}

    

