using des_fonds.Controller;
using des_fonds.encrypt;
using des_fonds.Finances;
using des_fonds.Mail;
namespace des_fonds.Users;

public static class UserManager
{
    

    /// <summary>
    /// edits users username info
    /// </summary>
    /// <param name="user">the user</param>
    /// <param name="newUsername">the new username</param>
    public static void EditUserDetails(User user, string username, string firstname, string lastname)
    {
        try
        {
            //perform validation
            //is username valid
            if (isValidUserName(username))
            {
                //is first name valid
                if (IsValidFirstName(firstname))
                {
                    //is last name valid
                    if (IsValidLastName(lastname))
                    {
                        //everything is valid set
                        user.Uname = username;
                        user.FirstName = firstname;
                        user.LastName = lastname;
                        DataController.UpdateUserEntry(user.Id, username, firstname, lastname);
                        Console.WriteLine("user name updated to :" + user.Uname);
                    }
                    else
                    {
                        throw new Exception("Last name not valid");
                    }
                }
                else
                {
                    throw new Exception("first name not valid");
                }
                
            }
            else
            {
                throw new Exception("username not valid");
            }

        }
        catch (Exception e)
        {
            //throw not valid message
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// gets the last 5 statements in the users statements list
    /// adds them to a string
    /// returns the string
    /// </summary>
    /// <param name="user"></param>
    /// <returns>last 5 statements in users statement list</returns>
    //public static string Last5Statements(User user)
    //{
    //    //it the length of the statements list
    //    int lengthOfStatements = user.Statements.Count;
    //    //if the length of statements is less than 5 or equal to 5 print the list out
    //    if (lengthOfStatements <= 5)
    //    {
    //        string strout = "";
    //        for(int i = 0; i < lengthOfStatements; i++)
    //        {
    //            strout += user.Statements[i].ToString() + "\n";
    //        }
    //        return strout;
    //    }
    //    else
    //    {
    //        //list is longer than 5
    //        string strout = "";
    //        //get the length and take a way five start loop from here
    //        for(int i = (lengthOfStatements - 5);i < lengthOfStatements; i++)
    //        {
    //            strout += user.Statements[i].ToString() + "\n";
    //        }
    //        return strout;

    //    }
        
    //}
    public static List<Statement> Last5Statements(User user)
    {

        int count = user.Statements.Count;
        return user.Statements.Skip(Math.Max(0, count - 5)).ToList();
    }
    //public static string Last5Bills(User user)
    //{
    //    int lengthOfBills = user.Bills.Count;
    //    if (lengthOfBills <= 5)
    //    {
    //        string strout = "";
    //        for (int i = 0; i < lengthOfBills; i++)
    //        {
    //            strout += user.Bills[i].ToString() + "\n";
    //        }
    //        return strout;
    //    }
    //    else
    //    {
    //        string strout = "";
    //        for (int i = (lengthOfBills - 5); i < lengthOfBills; i++)
    //        {
    //            strout += user.Bills[i].ToString() + "\n";
    //        }
    //        return strout;

    //    }

    //}
    
    public static bool IsValidDouble(string value)
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
    public static bool IsValidDate(string strDate)
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
    /// <summary>
    /// adds income to user statements
    /// </summary>
    /// <param name="user">the user adding the income</param>
    /// <param name="source">the source of income</param>
    /// <param name="strAmount">the amount of income</param>
    /// <param name="strDate">the date the income came in</param>
    /// <exception cref="Exception">throws an exception if the income is not valid</exception>
    public static void AddIncome(User user, string source, string strAmount, string strDate)
    {
        // check if source string is empty
        if (IsStrEmpty(source))
        {
            //string is empty
            throw new Exception("Financial name cant be empty");
        }
        // check amount string is empty
        else if (IsStrEmpty(strAmount))
        {
            //string is empty
            throw new Exception("Amount cant be empty");
        }
        //check if amount is a valid double
        else if (!IsValidDouble(strAmount))
        {
            // is not valid
            throw new Exception("amount is not in the correct format");
        }
        //check if date string is empty
        else if (IsStrEmpty(strDate))
        {
            //string is empty
            throw new Exception("Please select a date");
        }
        // check date is valid
        else if(!IsValidDate(strDate))
        {
            // date is not in the correct format
            throw new Exception("Date is not in the correct format");
        }
        //validation complete
        else
        {
            //create income
            double amount = double.Parse(strAmount);
            DateTime date = DateTime.Parse(strDate);
            Income income = new Income(source, amount, date);
            //add to users statements
            user.AddStatement(income);
            string type = "INCOME";
            DataController.addIncomeEntry(source, amount, date, type,user.Id);
        }

    }
    public static finalstatement GetIncomes(User user) 
    
    {
       finalstatement incomings = DataController.GetIncomeStatements(user.Id);
        return incomings;
    }

    public static finalstatement GetExpenses(User user) 
    {

      finalstatement outgoings =  DataController.GetExpenseStatements(user.Id);
        return outgoings;
    
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
            string type = "EXPENSE";
           DataController.addExpenseEntry(source,amount, date,type,user.Id);
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
        //MoneyApp app = MoneyApp.Instance;

        //foreach (User user in app.UserList)
        //{
        //    if (user.Uname == username)
        //    {
        //        //check password
        //        if (PassManager.CheckHash(user.Upass, password))
        //        {
        //            return user;
        //        }
        //        break;
        //    }
        //}
        try
        {
            
            User user = DataController.GetUserEntry(username);
            if (PassManager.CheckHash(user.Upass, password))
            {
                return user;
            }
            else
            {
                throw new Exception("User name or password incorrect");
            }
            
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        

    }
    public static bool IsStrEmpty(string str)
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

    public static void RegisterUser(string username, string password, string firstname, string lastname, string strAge, string street, string postcode, string city, string country)
    {
        try
        {
            //Validate registration fields
            if (isValidUserName(username))
                if(IsValidAge(strAge))
                    if(IsValidFirstName(firstname))
                        if(IsValidLastName(lastname))
                            if (IsStreetValid(street))
                                if (IsPostcodeValid(postcode))
                                    if (IsCityValid(city))
                                        if (IsCountryValid(country))
                                        {
                                            //All validation passed
                                            //hash password
                                            string hashPass = PassManager.HashPassword(password);
                                            int age= Convert.ToInt32(strAge);
                                            //create user
                                            DataController.AddUserEntry(firstname, lastname, age, username, hashPass, street, postcode, city, country, out int lastId);
                                            
                                            User user = new User(lastId, username, hashPass,firstname,lastname,age, street, postcode, city, country);
                                            //add user to instace list
                                            //MoneyApp.Instance.AddUser(user);
                                            
                                        }
        }
        catch (Exception ex)
        {
            //a validation failed, print message

            Console.WriteLine(ex.Message);
            throw new Exception(ex.Message);
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
    public static void SendMessage(User partyA, string username, string message)
    {
        try
        {
            User partyB = DataController.GetUserEntry(username);
           //User partyB = GetUserByUsername(username);
            if (UserManager.IsStrEmpty(message))
            {
                throw new Exception("Message cant be empty");
            }
           // Message msg = new Message(DateTime.Now, partyA, partyB, message);
            DataController.AddMessageEntry(partyA.Uname, partyA.Id, partyB.Uname, partyB.Id, message);
           
        }
        catch 
        {
            throw new Exception("Message not sent user not found");
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
    public static void AcceptInvite(Message message)
    {
        DataController.InsertHouseholdMember(message);
        
    }

    public static void RejectInvite(User user)
    {
        
    }
    public static Message ReceiveMessage(User partyB) 
    {
        try
        {

          Message message =  DataController.GetMessage(partyB.Id);
            return message;

        }
        catch
        {
            throw new Exception("issue");
        }

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

    

