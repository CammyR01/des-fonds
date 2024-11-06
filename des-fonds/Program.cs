using des_fonds.Calculator;
using des_fonds.Finances;
using des_fonds.Users;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoneyApp app = MoneyApp.Instance;
            CreateIncome();//creates an income.
            CreateExpense();//creates an expense.
            CalcAnnualIncome();//calculate the annual income
            AddIncomeExpenseToUserStatments(); // creates users, incomes, expenses, and display a list of each users statements
            TestCalculateMonthlyIncome();
            TestCalculateMonthlyExpense();
            CreateUser();
            TestRegisterLogin(app);
            DisplayStatement();
            EditUsername(app);
            //EditDetails();
            EditAddress(app);
            
        }
        /// <summary>
        /// test method to register a user and then logs user in
        /// throws exception if username or passwords are incorrect
        /// </summary>
        /// <param name="app">instance of app</param>
        public static void TestRegisterLogin(MoneyApp app)
        {
            //try register user
            try
            {
                //calls user manager method to register user
                UserManager.RegisterUser("peter", "password", "21 Jump Street", "g179as", "Gotham", "SomeCountry");
                Console.WriteLine("Registration Successful");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // username input and password for usermanager loginUser method
            string username = "peter";// change name to get error
            string password = "password";//change password to get error
            //login in user
            try
            {
                // if user login is successfull return the user profile
                User fetched_user = UserManager.LoginUser(username, password);
                Console.WriteLine("login successful");
                //display logged in user
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
        /// <summary>
        /// test method to create an expense
        /// </summary>
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
        /// <summary>
        /// test method to calculate the annual income
        /// logs user in and calculates the annual income for the given year
        /// </summary>
        public static void CalcAnnualIncome()
        {
            // set variables annual income and year to calculate
            double annualIncome = 0;
            int year = 2024;
            try
            {
                //log user in 
                User user = UserManager.LoginUser("suzan", "pass3");
                //calculate annual income using finance calculator class and calculateAnnualIncome method
                annualIncome = FinanceCalculator.CalculateAnnualIncome(user, year);
                //display user and annual income total
                Console.WriteLine(user + "\n" + "annual Income: £" + annualIncome);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void DisplayStatement()
        {
            // Single income and expense instance
            Income income = new Income("Job", 1500.00, new DateTime(2024, 10, 12));
            Expense expense = new Expense("Groceries", 150.00, new DateTime(2024, 10, 10));

            // Use `DisplayStatements` to show both entries
            income.DisplayStatements(income, expense);
        }
        /// <summary>
        /// creates a user
        /// displays the users
        /// </summary>
        public static void CreateUser()
        {
            string uName = "JOSH";
            string uPass = "MCI";
            User user = new User(uName, uPass);
            User user1 = new User("Ash", "passowrd");

            Console.WriteLine(user);
            Console.WriteLine(user1);
        }
        public static void EditUsername(MoneyApp app)
        {
            //login in suzan
            try
            {
                //suzan login details
                string username = "suzan";
                string password = "pass3";
                
                //try login in user
                User user = UserManager.LoginUser(username, password);
                //if login in successfull change name from "suzan" to "susan"
                string oldName = user.Uname; //get old name from class
                string newName = "susan"; // the new name
                //edit the details
                UserManager.EditUserDetails(user, newName);
                Console.WriteLine("Edit was successful:\nOld Name: " + oldName + "\nNew Name: " + user.Uname);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EditAddress(MoneyApp app)
        {
            try
            {
                //login ash
                string username = "ash";
                string password = "pass";
                User user = UserManager.LoginUser(username, password);
                Console.WriteLine("Old Address:\n" + user.Address);
                //change address
                string street = "17 New Street";
                string postcode = "NewPCode";
                string city = "New City";
                string country = "New Country";
                UserManager.EditAddress(user, street, postcode, city, country);
                Console.WriteLine("Address Changed:\n" + user.Address);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        /// <summary>
        /// test method to add income and expense to created users
        /// </summary>
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
        /// <summary>
        /// Tests method to calculate monthly income
        /// </summary>
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
        /// <summary>
        /// test method to calculate the montly expenses
        /// </summary>
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
