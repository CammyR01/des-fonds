namespace des_fonds.Finances
{

    public class Expense : Statement
    {
        private string category;// the category of the expense
        //Properties
        public string Category { get => category; set => category = value; }

        //Contructor
        public Expense(string category, double amount, DateTime date):base(amount, date)
        {
            this.category = category;
        }
        public Expense(string category, double amount, DateTime date, string type):base(amount, date, type)
        {
            this.category=category;
            
        }
        /// <summary>
        /// display a string representation of an expense statement
        /// </summary>
        /// <returns>returns a string representation of an expense</returns>
        public override string ToString() 
        {

            
            string strout = string.Format("| {0,-12} | {1,-18} \t\t| £{2,-15} \t| {3,-15:N2} |\n-----------------------------------------------------------------------------------------",
                Type, category, Amount, Date.ToShortDateString());
            return strout;
        
        }
            
    }
}
