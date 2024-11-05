namespace des_fonds.Users;

public class UserManager
{
    private User user;
    private Address address;

    public UserManager()
    {
        // Default user details
        string uName = "Sugar";
        string uPass = "Sugar1";

        string streetAddress = "808 Kanye West";
        string postCode = "TLOP";
        string city = "Chicago";
        string country = "America";

        address = new Address(streetAddress, postCode, city, country);
        // Initialise the User and Address
        user = new User(uName, uPass, address);
    }

    public void EditUserDetails(string? newUsername, string? newPassword)
    {
        if (user != null)
        {
            if (!string.IsNullOrEmpty(newUsername))
            {
                user.Uname = newUsername;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Upass = newPassword;
            }

            Console.WriteLine("User details updated successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    public void EditAddress(string? newStreet, string? newPostcode, string? newCity, string? newCountry)
    {
        if (address != null)
        {
            if (!string.IsNullOrEmpty(newStreet))
            {
                address.StreetAddress = newStreet;
            }

            if (!string.IsNullOrEmpty(newPostcode))
            {
                address.PostCode = newPostcode;
            }

            if (!string.IsNullOrEmpty(newCity))
            {
                address.City = newCity;
            }

            if (!string.IsNullOrEmpty(newCountry))
            {
                address.Country = newCountry;
            }

            Console.WriteLine("Address updated successfully.");
        }
        else
        {
            Console.WriteLine("Address not found.");
        }
    }

    public string GetUserDetails()
    {
        return user != null ? user.ToString() : "User not found.";
    }

    public string GetAddressDetails()
    {
        return address != null ? address.ToString() : "Address not found.";
    }
}
