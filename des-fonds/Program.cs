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
            Income income = new Income(source, amount, Date);
            //display income
            Console.WriteLine(income + "\n");
        }
        public static void CreateExpense()
        {
            //attributes for expense
            string category = "Rent";
            double amount = 455.88;
            DateTime date = new DateTime(2024, 10, 31);
            //create expense
            Expense expense = new Expense(category, amount, date);
            //display expense
            Console.WriteLine(expense + "\n");
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
    }
}
