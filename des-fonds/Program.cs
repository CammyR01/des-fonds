using des_fonds.Calculator;
using des_fonds.Controller;
using des_fonds.Finances;
using des_fonds.Mail;
using des_fonds.Users;
using des_fonds.encrypt;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MoneyApp app = MoneyApp.Instance;
            //CreateIncome();//creates an income.
            //CreateExpense();//creates an expense.
            //CreateBill();//creates a bill
            //EditStatus();
            //CalcAnnualIncome();//calculate the annual income
            //AddIncomeExpenseToUserStatments(); // creates users, incomes, expenses, and display a list of each users statements
            //TestCalculateMonthlyIncome();
            //TestCalculateMonthlyExpense();
            //CreateUser();
            //TestRegisterLogin(app);
            //DisplayStatement();
            //EditUsername(app);
            ////EditDetails();
            //EditAddress(app);
            //RemoveUser(app);
            //CreateHouseHead(app);
            //SendInviteToHousehold(app);
            //receive_invite(app);
            //AcceptInvite(app);
            //CheckAcceptInvite(app);
            //checkAddressChangeForHouseMember(app);
            databaseTest();
            //databaseLoader();

        }
        private static void databaseTest() 
        {
            try
            {
                DataController.OpenConnection();//connecects to database
                DataController.CreateUserTable();//create user table
                DataController.CreateAddressTable();//create addresses table
                DataController.CreateStatementTable();
                DataController.CreateMessageTable();
                DataController.CreateHouseHoldTable();
                DataController.CreateBillTable();

                // add a user
                int id = 1000;
                string fname = "testname";
                string lname = "lastName";
                int age = 44;
                string uname = "testmeUsername";
                string password = PassManager.HashPassword("password");
                string street = "15 Main street";
                string city = "Glasgow";
                string postcode = "G71 7bk";
                string country = "scotland";

                DataController.AddUserEntry(fname, lname, age, uname, password, street, postcode, city, country, out int lastId) ;
                Console.WriteLine("adduserentry success");

                User user = DataController.GetUserEntry(uname);
                Console.WriteLine("got user back");
                Console.WriteLine(user);

                //DataController.CreateAddressTable();// create address table
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void databaseLoader()
        {
            try
            {
                DataController.OpenConnection();
                DataController.CreateUserTable();
                DataController.CreateAddressTable();
                DataController.CreateStatementTable();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                UserManager.RegisterUser("peterKool", "password","peter", "griffen", "32", "21 Jump Street", "g179as", "Gotham", "SomeCountry");
                Console.WriteLine("Registration Successful");
            }
            catch (Exception ex)
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

        public static void CreateBill()
        {
            string billName = "Spotify";
            double amount = 12.50;
            DateTime dueDate = new DateTime(2924, 12, 20);

            Bill bill1 = new Bill(billName,Status.Pending, amount, dueDate);

            Console.WriteLine(bill1 + "\n");

        }

        public static void EditStatus()
        {
            string billName = "Mug";
            double amount = 13.50;
            DateTime dueDate = new DateTime(2924, 12, 20);

            Bill bill1 = new Bill(Status.Pending)
            {
                BillName = billName,
                Amount = amount,
                DueDate = dueDate
            };

            // Output the bill before status change
            Console.WriteLine("Before Status Edit:\n" + bill1 + "\n");

            // Editing the status of the bill
            bill1.Status = Status.Paid;  // Change the status here

            // Output the bill after status change
            Console.WriteLine("After Status Edit:\n" + bill1);
        }


        public static void RemoveBill()
        {
            string billName = "Electricity";
            double amount = 15.50;
            DateTime dueDate = DateTime.Now;

            Bill bill = new Bill(billName, Status.Pending, amount, dueDate);
            Console.WriteLine("Bill created "+ bill);

            
        }


        /// <summary>
        /// test method to calculate the annual income
        /// logs user in and calculates the annual income for the given year
        /// </summary>
        public static void CalcAnnualIncome()
        {
            // set variables annual income and year to calculate
            //double annualIncome = 0;
            //int year = 2024;
            try
            {
                //log user in 
                User user = UserManager.LoginUser("kruel", "password");
                user.Statements.Add(new Expense("wage", 1234.44, DateTime.Now));
                user.Statements.Add(new Income("wage", 1234.44, DateTime.Now));
                user.Statements.Add(new Income("wage", 1234.44, DateTime.Now));
                user.Statements.Add(new Expense("wage", 1234.44, DateTime.Now));
                user.Statements.Add(new Expense("wage", 1234.44, DateTime.Now));
                //calculate annual income using finance calculator class and calculateAnnualIncome method
                //annualIncome = FinanceCalculator.CalculateIncome(user, year);
                //display user and annual income total
                //Console.WriteLine(user + "\n" + "annual Income: £" + annualIncome);
               
                
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
        //public static void CreateUser()
        //{
        //    string uName = "JOSH";
        //    string uPass = "MCI";
        //    User user = new User(uName, uPass);
        //    User user1 = new User("Ash", "passowrd");

        //    Console.WriteLine(user);
        //    Console.WriteLine(user1);
        //}
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
                string firstname = "frist";
                string lastname = "griffin";
                //edit the details
                UserManager.EditUserDetails(user, newName, firstname, lastname);
                Console.WriteLine("Edit was successful:\nOld Name: " + oldName + "\nNew Name: " + user.Uname);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void RemoveUser(MoneyApp app)
        {
            // tryn login and remove the user
            try
            {
                //user details
                string username = "ash";
                string password = "pass";

                // attempt to log the user in
                User user = UserManager.LoginUser(username, password);

                // if login is successful proceed with removal
                Console.WriteLine("User logged in successfully: " + user.Uname);

                // Remove the user
                UserManager.RemoveUser(user);
                Console.WriteLine("User removal successful: " + user.Uname);
            }
            catch (Exception ex)
            {
                // display an error message if login or removal fails
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
            //User user1 = UserPopulate("ash", "pass");
            //User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            //user1.AddStatement(in1);
            //user1.AddStatement(in2);
            //user1.AddStatement(ex1);
            //user1.AddStatement(ex2);
            //user2.AddStatement(in3);
            //user2.AddStatement(ex3);
            //list all statements for user1
            Console.WriteLine("USER 1 STATEMENTS\n");
            //foreach (Statement s in user1.Statements)
            //{

            //    Console.WriteLine(s + "\n");
            //}
            ////list all statements for user2
            //Console.WriteLine("USER 2 STATEMENTS");
            //foreach (Statement s1 in user2.Statements)
            //{
            //    Console.WriteLine(s1 + "\n");
            //}
        }
        /// <summary>
        /// Tests method to calculate monthly income
        /// </summary>
        public static void TestCalculateMonthlyIncome()
        {
            // add income and expenses to users
            //User user1 = UserPopulate("ash", "pass");
            //User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            //user1.AddStatement(in1);
            //user1.AddStatement(in2);
            //user1.AddStatement(ex1);
            //user1.AddStatement(ex2);
            //user2.AddStatement(in3);
            //user2.AddStatement(ex3);
            // calculate monthly income
            int month = 11;
            int year = 2024;
            //double monthly_total = FinanceCalculator.CalculateIncome(user1, month, year);
            // two incomes "in1" + "in2" total to 1284.87
            //Console.WriteLine("The total for " + month + "/" + year + " is £" + monthly_total + "\n");
        }
        /// <summary>
        /// test method to calculate the montly expenses
        /// </summary>
        public static void TestCalculateMonthlyExpense()
        {
            // add income and expenses to users
            //User user1 = UserPopulate("ash", "pass");
            //User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 11, 2));
            Income in3 = CreateIncomePopulate("Birthday Money", 100, new DateTime(2024, 5, 22));
            //create expense
            Expense ex1 = CreateExpensePopulate("Rent", 553.89, new DateTime(2024, 11, 1));
            Expense ex2 = CreateExpensePopulate("spotify", 19.99, new DateTime(2024, 10, 2));
            Expense ex3 = CreateExpensePopulate("wifi", 62.00, new DateTime(2024, 10, 2));
            //add income and expense to users statements
            //user1.AddStatement(in1);
            //user1.AddStatement(in2);
            //user1.AddStatement(ex1);
            //user1.AddStatement(ex2);
            //user2.AddStatement(in3);
            //user2.AddStatement(ex3);

            int month = 10;
            int year = 2024;
            double monthly_expense;

            //monthly_expense = FinanceCalculator.CalculateExpense(user2, month, year);
            //Console.WriteLine("The monthly expense total is: £" + monthly_expense);
        }
        public static void CreateHouseHead(MoneyApp app)
        {
            try
            {
                User user = UserManager.LoginUser("susan", "pass3");

                user.CreateHousehold();
                string a = user.Address.Street;
                Console.WriteLine("\nis user a househead: " + user.IsHeadOfHouse);
                Console.WriteLine("The household Address is:\n" + user.Household.Head.Address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SendInviteToHousehold(MoneyApp app)
        {
            try
            {
                // login in user
                User a = UserManager.LoginUser("susan", "pass3");
                //is a househead
                bool ishead = a.IsHeadOfHouse;
                
                if (ishead)
                {
                    string username = "mel";
                    string message = "hey mel, i am inviting you to join my house as a member";

                    a.Household.SendInvite(a, username, message);
                    Console.WriteLine("Invite sent");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void receive_invite(MoneyApp app)
        {
            try
            {
                User a = UserManager.LoginUser("mel", "pass4");
                int NotificationCount = a.NotificationCount;
                bool Notificationflag = a.NewNotification;
                Message invite = a.Messages.Last();
                Console.WriteLine("\nNotification count: " + NotificationCount);
                Console.WriteLine("Notification flag: " + Notificationflag);
                Console.WriteLine("\n" + invite);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AcceptInvite(MoneyApp app)
        {
            try
            {
                //log user mel in 
                User a = UserManager.LoginUser("mel", "pass4");
                //check notification
                int noteCount = a.NotificationCount;
                bool noteflag = a.NewNotification;
                Console.WriteLine($"\n{a.Uname} has {noteCount} notification");
                Console.WriteLine($"Checking noteflag: {noteflag}");

                //user gets invitation
                Message msg = a.Messages.Last();
                if (msg is Invite invite)
                {
                    //Console.WriteLine("New Household Invite");
                    //Console.WriteLine(invite);
                    // user can accept or decline, this test is for accept.
                    invite.Accept();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void CheckAcceptInvite(MoneyApp app)
        {
            try
            {
                User user = UserManager.LoginUser("susan", "pass3");
                int noteCount = user.NotificationCount;
                bool noteflag = user.NewNotification;

                Console.WriteLine($"\n{user.Uname} has {noteCount} notification\nChecking noteflag: {noteflag}\n");
                // open message reply
                Message msg = user.Messages.Last();
                if (msg is Invite invite)
                {
                    Console.WriteLine(invite);

                }

                
   
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void checkAddressChangeForHouseMember(MoneyApp app)
        {
            try
            {
                User userA = UserManager.LoginUser("mel", "pass4");
                User userB = UserManager.LoginUser("susan", "pass3");

                string userA_name = userA.Uname;
                string userB_name = userB.Uname;
                bool isUserA_head = userA.IsHeadOfHouse;
                bool isUserB_head = userB.IsHeadOfHouse;
                if (isUserA_head) {
                    Address householdAddress = userA.Household.Head.Address;
                    Console.WriteLine("this is the head of house:\n " + userA.Household.Head.Uname);
                }
                else if (isUserB_head)
                {
                    Address householdAddress = userB.Household.Head.Address;
                    Console.WriteLine("this is the head of house:\n " + userB.Household.Head.Uname);
                }
                if (userA.Address.Equals(userB.Address))
                {
                    Console.WriteLine("there address are the same");
                }
                else
                {
                    Console.WriteLine("ERROR: there addresses are different, should be same as in same household");
                }
                foreach(User member in userB.Household.Members)
                {
                    Console.WriteLine(member);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Creates users
        //public static User UserPopulate(string uname, string upass)
        //{
        //    return new User(uname, upass);
        //}
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
