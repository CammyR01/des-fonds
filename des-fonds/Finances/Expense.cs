using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// display a string representation of an expense statement
        /// </summary>
        /// <returns>returns a string representation of an expense</returns>
        public override string ToString() 
        {
            string strout = string.Format("Category: {0}\nAmount: £{1}\nDate Spent: {2}",
               Category, Amount, Date.ToShortDateString());
            return strout;
        
        }
            
    }
}
