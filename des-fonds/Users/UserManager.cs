using System.Runtime.InteropServices;
using des_fonds.encrypt;
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

    //public static void EditUserDetails(string? newUsername, string? newPassword)
    //{
    //    if (user != null)
    //    {
    //        if (!string.IsNullOrEmpty(newUsername))
    //        {
    //            user.Uname = newUsername;
    //        }

    //        if (!string.IsNullOrEmpty(newPassword))
    //        {
    //            user.Upass = newPassword;
    //        }

    //        Console.WriteLine("User details updated successfully.");
    //    }
    //    else
    //    {
    //        Console.WriteLine("User not found.");
    //    }
    //}

    //public void EditAddress(string? newStreet, string? newPostcode, string? newCity, string? newCountry)
    //{
    //    if (address != null)
    //    {
    //        if (!string.IsNullOrEmpty(newStreet))
    //        {
    //            address.StreetAddress = newStreet;
    //        }

    //        if (!string.IsNullOrEmpty(newPostcode))
    //        {
    //            address.PostCode = newPostcode;
    //        }

    //        if (!string.IsNullOrEmpty(newCity))
    //        {
    //            address.City = newCity;
    //        }

    //        if (!string.IsNullOrEmpty(newCountry))
    //        {
    //            address.Country = newCountry;
    //        }

    //        Console.WriteLine("Address updated successfully.");
    //    }
    //    else
    //    {
    //        Console.WriteLine("Address not found.");
    //    }
    //}

    //public string GetUserDetails()
    //{
    //    return user != null ? user.ToString() : "User not found.";
    //}

    //public string GetAddressDetails()
    //{
    //    return address != null ? address.ToString() : "Address not found.";
    //}
    public static User LoginUser(string username, string password)
    {
        MoneyApp app = MoneyApp.Instance;
        foreach(User user in app.UserList)
        {
            if(user.Uname == username)
            {
                //check password
                if(Sha256Hasher.CheckHash(user.Upass, password))
                {
                    return user;
                }
                break;
            }
        }
        throw new Exception("Username or password incorrect");

    }

    public static void RegisterUser(string username, string password, string street, string postcode, string city, string country)
    {
        if (username.Length > 0)
        {         
            if(street.Length > 0)
            {
                if (postcode.Length > 0)
                {
                    if(city.Length > 0)
                    {
                        if (country.Length > 0)
                        {
                            string hashPass = Sha256Hasher.Hash(password);
                            User user = new User(username, hashPass, street, postcode, city, country);
                            MoneyApp.Instance.AddUser(user);
                        }//if5
                        else
                        {
                            throw new Exception("Country cant be empty");
                        }
                    }//if4
                    else
                    {
                        throw new Exception("City cant be empty");
                    }
                }//if3
                else
                {
                    throw new Exception("Postcode cant be empty");
                }
            }//if2
            else
            {
                throw new Exception("Street cant be empty");
            }
        }//if1
        else
        {
            throw new Exception("username cant be empty");
        }
    }
}
