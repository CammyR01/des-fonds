using des_fonds.Finances;
using des_fonds.Users;
using System.Runtime.InteropServices;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateIncome();//creates an income.
            CreateExpense();//creates an expense.
                            // CalcAnnualIncome();//calculate the annual income
            AddIncomeExpenseToUserStatments(); // creates users, incomes, expenses, and display a list of each users statements
            CreateUser();
            DisplayStatement();
            EditDetails();
            
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

        public static void EditDetails()
        {
            // default user details
            string uName = "Sugar";
            string uPass = "Sugar1";
            User user = new User(uName, uPass);
            Console.WriteLine("Before Update:\n" + user);

            // Prompt for new username
            Console.Write("Enter new username (or press Enter to keep the current username): ");
            string? newUsername = Console.ReadLine();

            // Prompt for new password
            Console.Write("Enter new password (or press Enter to keep the current password): ");
            string? newPassword = Console.ReadLine();

            // Update user details using the EditUserDetails method
            user.EditUserDetails(newUsername, newPassword);

            Console.WriteLine("\nAfter Update:\n" + user);
        }
        public static void AddIncomeExpenseToUserStatments()
        {
            //create users
            User user1 = UserPopulate("ash", "pass");
            User user2 = UserPopulate("bob", "pass2");
            //create income
            Income in1 = CreateIncomePopulate("Wage", 1234.99, new DateTime(2024, 11, 1));
            Income in2 = CreateIncomePopulate("Side Hustle", 49.88, new DateTime(2024, 10, 2));
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
