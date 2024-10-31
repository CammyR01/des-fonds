using des_fonds.Finances;

namespace des_fonds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateIncome();
            CreateExpense();
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
    }
}
