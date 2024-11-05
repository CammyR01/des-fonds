using des_fonds.Finances;
using des_fonds.Users;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CreateIncome();//creates an income.
            CreateExpense();//creates an expense.
                            // CalcAnnualIncome();//calculate the annual income
            CreateUser();
            DisplayStatement();

            EditDetails();
            EditAddress();
        }
        /// <summary>
        /// test method to create an income
        /// </summary>
        public static void CreateIncome()
        {
            //attributes for income
            string source = "Wage";
            double amount = 1234.45;
            DateTime Date = new DateTime(2024, 10, 29);
            //create income
            Income income1 = new Income(source, amount, Date);
            Income income2 = new Income("side job", 55.00, new DateTime(2024, 11, 1));
            //display income
            Console.WriteLine(income1 + "\n");
            Console.WriteLine(income2+ "\n");
        }
        public static void CreateExpense()
        {
            //attributes for expense
            string category = "Rent";
            double amount = 455.88;
            DateTime date = new DateTime(2024, 10, 31);
            //create expense
            Expense expense1 = new Expense(category, amount, date);
            //display expense
            Console.WriteLine(expense1 + "\n");
        }
        public static void CalcAnnualIncome()
        {
            //still to be implemented

            
        }
        public static void DisplayStatement()
        {
            // Single income and expense instance
            Income income = new Income("Job", 1500.00, new DateTime(2024, 10, 12));
            Expense expense = new Expense("Groceries", 150.00, new DateTime(2024, 10, 10));

            // Use `DisplayStatements` to show both entries
            income.DisplayStatements(income, expense);
        }

        public static void CreateUser()
        {
            string uName = "JOSH";
            string uPass = "MCI";
            User user = new User(uName, uPass);
            User user1 = new User("Ash", "passowrd");

            Console.WriteLine(user);
            Console.WriteLine(user1);
        }
        public static void EditDetails()
        {
            UserManager userManager = new UserManager();

            // Display current user details
            Console.WriteLine("User Details Before Update:\n" + userManager.GetUserDetails());

            // Prompt for new username
            Console.Write("Enter new username (or press Enter to keep the current username): ");
            string? newUsername = Console.ReadLine();

            // Prompt for new password
            Console.Write("Enter new password (or press Enter to keep the current password): ");
            string? newPassword = Console.ReadLine();

            // Update user details
            userManager.EditUserDetails(newUsername, newPassword);

            // Display updated user details
            Console.WriteLine("\nUser Details After Update:\n" + userManager.GetUserDetails());
        }

        public static void EditAddress()
        {
            UserManager userManager = new UserManager();
            Console.WriteLine("===============================================================");
            // Display current address details
            Console.WriteLine("\n\nAddress Before Update:\n" + userManager.GetAddressDetails());

            // Prompt for new address details
            Console.Write("Enter a new Street name (or press Enter to keep current): ");
            string? newStreetAddress = Console.ReadLine();

            Console.Write("Enter a new City (or press Enter to keep current): ");
            string? newCity = Console.ReadLine();

            Console.Write("Enter a new Postcode (or press Enter to keep current): ");
            string? newPostcode = Console.ReadLine();

            Console.Write("Enter a new Country (or press Enter to keep current): ");
            string? newCountry = Console.ReadLine();

            // Update address details
            userManager.EditAddress(newStreetAddress, newPostcode, newCity, newCountry);

            // Display updated address details
            Console.WriteLine("\nAddress After Update:\n" + userManager.GetAddressDetails());
        }



    }
}
