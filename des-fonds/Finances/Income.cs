namespace des_fonds.Finances
{
    public class Income : Statement
    {
        //Attributes
        private string source; //the name of the source of income

        //Properties
        public string Source { get => source; set => source = value; }


        //Constructor
        public Income(string source, double amount, DateTime date):base(amount, date)
        {
            this.source = source;
        }
        public Income(string source, double amount, DateTime date, string type): base(amount, date, type)
        {
            this.source = source;
        }



        /// <summary>
        /// Displays a representation of an Income statement
        /// </summary>
        /// <returns>String Representation of an income</returns>
        public override string ToString()
        {
            string strout = string.Format("Income Id: {0}\n" +
                "Source: {1}\n" +
                "Amount: £{2}\n" +
                "Date Recieved: {3}"
                ,Id, Source, Amount, Date.ToShortDateString());
            return strout;
        }
    }
}
