using des_fonds.Calculator;
using des_fonds.Finances;
using des_fonds.Users;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoneyApp app = MoneyApp.Instance;
            CreateIncome();//creates an income.
            CreateExpense();//creates an expense.
                            // CalcAnnualIncome();//calculate the annual income
            AddIncomeExpenseToUserStatments(); // creates users, incomes, expenses, and display a list of each users statements
            TestCalculateMonthlyIncome();
            TestCalculateMonthlyExpense();
            CreateUser();
            TestRegisterLogin(app);
            DisplayStatement();
            //EditDetails();
            //EditAddress();
            
        }
        public static void TestRegisterLogin(MoneyApp app)
        {
            //try register user
            try
            {
                UserManager.RegisterUser("peter", "password", "21 Jump Street", "g179as", "Gotham", "SomeCountry");
                Console.WriteLine("Registration Successful");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string username = "peter";// change name to get error
            string password = "password1";//change password to get error
            //login in user
            try
            {
                User fetched_user = UserManager.LoginUser(username, password);
                Console.WriteLine("login successful");
                Console.WriteLine(fetched_user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
            Console.WriteLine(income2 + "\n");
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

        //public static void EditDetails()
        //{
        //    UserManager userManager = new UserManager();

        //    // Display current user details
        //    Console.WriteLine("User Details Before Update:\n" + userManager.GetUserDetails());

        //    // Prompt for new username
        //    Console.Write("Enter new username (or press Enter to keep the current username): ");
        //    string? newUsername = Console.ReadLine();

        //    // Prompt for new password
        //    Console.Write("Enter new password (or press Enter to keep the current password): ");
        //    string? newPassword = Console.ReadLine();

        //    // Update user details
        //    userManager.EditUserDetails(newUsername, newPassword);

        //    // Display updated user details
        //    Console.WriteLine("\nUser Details After Update:\n" + userManager.GetUserDetails());
        //}

        //public static void EditAddress()
        //{
        //    UserManager userManager = new UserManager();
        //    Console.WriteLine("===============================================================");
        //    // Display current address details
        //    Console.WriteLine("\n\nAddress Before Update:\n" + userManager.GetAddressDetails());

        //    // Prompt for new address details
        //    Console.Write("Enter a new Street name (or press Enter to keep current): ");
        //    string? newStreetAddress = Console.ReadLine();

        //    Console.Write("Enter a new City (or press Enter to keep current): ");
        //    string? newCity = Console.ReadLine();

        //    Console.Write("Enter a new Postcode (or press Enter to keep current): ");
        //    string? newPostcode = Console.ReadLine();

        //    Console.Write("Enter a new Country (or press Enter to keep current): ");
        //    string? newCountry = Console.ReadLine();

        //    // Update address details
        //    userManager.EditAddress(newStreetAddress, newPostcode, newCity, newCountry);

        //    // Display updated address details
        //    Console.WriteLine("\nAddress After Update:\n" + userManager.GetAddressDetails());
        //}
        public static void AddIncomeExpenseToUserStatments()
        {
            //create users
            User user1 = UserPopulate("ash", "pass");
            User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            user1.AddStatement(in1);
            user1.AddStatement(in2);
            user1.AddStatement(ex1);
            user1.AddStatement(ex2);
            user2.AddStatement(in3);
            user2.AddStatement(ex3);
            //list all statements for user1
            Console.WriteLine("USER 1 STATEMENTS\n");
            foreach (Statement s in user1.Statements)
            {

                Console.WriteLine(s + "\n");
            }
            //list all statements for user2
            Console.WriteLine("USER 2 STATEMENTS");
            foreach (Statement s1 in user2.Statements)
            {
                Console.WriteLine(s1 + "\n");
            }
            
            
        }

        public static void TestCalculateMonthlyIncome()
        {
            // add income and expenses to users
            User user1 = UserPopulate("ash", "pass");
            User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            user1.AddStatement(in1);
            user1.AddStatement(in2);
            user1.AddStatement(ex1);
            user1.AddStatement(ex2);
            user2.AddStatement(in3);
            user2.AddStatement(ex3);
            // calculate monthly income
            int month = 11;
            int year = 2024;
            double monthly_total = FinanceCalculator.CalculateMonthlyIncome(user1, month, year);
            // two incomes "in1" + "in2" total to 1284.87
            Console.WriteLine("The total for " + month + "/" + year + " is £" + monthly_total + "\n");
        }
        public static void TestCalculateMonthlyExpense()
        {
            // add income and expenses to users
            User user1 = UserPopulate("ash", "pass");
            User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            user1.AddStatement(in1);
            user1.AddStatement(in2);
            user1.AddStatement(ex1);
            user1.AddStatement(ex2);
            user2.AddStatement(in3);
            user2.AddStatement(ex3);

            int month = 10;
            int year = 2024;
            double monthly_expense;

            monthly_expense = FinanceCalculator.CalculateMonthlyExpense(user2, month, year);
            Console.WriteLine("The monthly expense total is: £" + monthly_expense);
        }

        // Creates users
        public static User UserPopulate(string uname, string upass)
        {
            return new User(uname, upass);
        }
        // creates incomes
        public static Income CreateIncomePopulate(string source, double amount, DateTime date)
        {
            return new Income(source, amount, date);
        }
        // creates expenses
        public static Expense CreateExpensePopulate(string category, double amount, DateTime date)
        {
            return new Expense(category, amount, date);
        }
        
    }
}
