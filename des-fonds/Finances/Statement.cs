namespace des_fonds.Finances
{
    public abstract class Statement
    {
        private double amount; // the amount in the statement
        private DateTime date; // the date given to the statement

        //Properties (Getter & Setter)
        public double Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }


        //Constructor
        public Statement(double amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }

        
    }
}
