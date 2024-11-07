using des_fonds.encrypt;
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
    public static void EditUserDetails(User user, string newUsername)
    {
        try
        {
            //perform validation
            if (isValidUserName(newUsername))
            {
                //username is valid, set new name
                user.Uname = newUsername;
                Console.WriteLine("user name updated to :" + user.Uname);
            }

        }
        catch(Exception e)
        {
            //throw not valid message
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
        else if(username.Length < 3)
        {
            //user name too short
            throw new Exception("username must be longer than 3 characters");
        }
        //validation passed
        return true;
        
    }

    public static void EditAddress(User user,string newStreet, string newPostcode, string newCity, string newCountry)
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
        else if(newCity.Length < 4)
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
        else if(newCountry.Length < 4)
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

    public static void RegisterUser(string username, string password, string street, string postcode, string city, string country)
    {
        try
        {
            //Validate registration fields
            if (isValidUserName(username))
                if (IsStreetValid(street))
                    if (IsPostcodeValid(postcode))
                        if (IsCityValid(city))
                            if (IsCountryValid(country))
                            {
                                //All validation passed
                                //hash password
                                string hashPass = Sha256Hasher.Hash(password);
                                //create user
                                User user = new User(username, hashPass, street, postcode, city, country);
                                //add user to instace list
                                MoneyApp.Instance.AddUser(user);
                            }
        }
        catch(Exception ex)
        {
            //a validation failed, print message
            Console.WriteLine(ex.Message);
        }
            
           
                            
                        
    }
            
}

    

