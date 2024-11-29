namespace des_fonds.Finances
{
    public abstract class Statement
    {
        
        private int id;
        private double amount;
        private DateTime date;
        private string type;

        // Properties
        public double Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Id { get => id; set => id = value; }
        public string Type { get => type; set => type = value; }
        // Constructor
        public Statement(double amount, DateTime date)
        {            
            this.amount = amount;
            this.date = date;
            this.type = "Not Set";
        }
        public Statement(double amount, DateTime date, string type)
        {
            this.amount = amount;
            this.date = date;
            this.type = type;
        }


        public override string ToString()
        {
            string strout = "=========== STATEMENT ===========\n";
            strout += string.Format("{0, -10},{1,-10} | \t{2, -10} | {3, -10}\n\n",
                "Type", "category", "Amount", "Date");
            return strout;
        }
        // Display method accepting single income and expense
        public void DisplayStatements(Income income, Expense expense)
        {
            Console.WriteLine("==================== STATEMENT ====================\n");

            //Headers
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | {3,-10} | {4,-12}",
                              "Entry ID", "Type", "Category", "Amount", "Date");

            //Seperator
            Console.WriteLine(new string('-', 65));

            //int entryId = 1;
            double totalIncome = income.Amount;
            double totalExpense = expense.Amount;

            // Display income
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | £{3,-8:N2} | {4,-12}",
                income.Id, "Income", income.Source, income.Amount, income.Date.ToShortDateString());
            //entryId++;

            // Display expense
            Console.WriteLine("{0,-10} | {1,-10} | {2,-15} | £{3,-8:N2} | {4,-12}",
                expense.Id, "Expense", expense.Category, expense.Amount, expense.Date.ToShortDateString());

            Console.WriteLine(new string('-', 65));
            Console.WriteLine("Total Income:  £{0,-8:N2}", totalIncome);
            Console.WriteLine("Total Expense: £{0,-8:N2}", totalExpense);
            Console.WriteLine("===================================================");
        }
    }
}