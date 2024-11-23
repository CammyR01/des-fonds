using des_fonds.Finances;
using des_fonds.Users;

namespace des_fonds.Calculator
{
    public static class FinanceCalculator
    {
        /// <summary>
        /// Calculates the monthly total income
        /// requires the month the user wants the total income from
        /// requires the year the user wants the total income from
        /// calculates the total income for the specified month and year for all expense statements
        /// </summary>
        /// <param name="user">the user </param>
        /// <param name="month">the month in number representation</param>
        /// <param name="year">the year the user specified</param>
        /// <returns>the total income for the specified month and year for all income statements</returns>
        public static double CalculateIncome(User user, int month, int year)
        {
            ///wouldnt this take in month and income as parameters instead of year?
            ///but wouldnt that then look at all the statements with that month regardless of the year,
            ///and then give a total for feb 2023 and feb 2024 when we only want the month feb of 2024?
            
            // set month total to 0
            double month_total = 0;
            //loop through the users statements
            foreach(Statement s in user.Statements)
            {
                //check if statement is income
                if(s is Income income)
                {
                    // if it is income check the month and the year
                    if (income.Date.Month == month && income.Date.Year == year)
                    {
                        // if it matches add the amount to month total
                        month_total += income.Amount;
                    }
                }                
            }
            //round the total to 2 decimals and return total
            return Math.Round(month_total,2);
        }
        /// <summary>
        /// calculates the monthly total expense
        /// requires the month the user wants the total from
        /// requires the year the user wants the total from
        /// calculates the total expense for the specified month and year for all expense statements
        /// </summary>
        /// <param name="month">the month in number representation</param>
        /// <param name="year">the year the user specified</param>
        /// <returns>the total expense for specified month and year for all expenses statements</returns>
        public static double CalculateExpense(User user, int month, int year)
        {
            // set the yearly total to 0
            double monthly_total = 0;
            // loop through users statements
            foreach (Statement s in user.Statements)
            {
                //check if it is expense
                if (s is Expense expense)
                {
                    //if it is expense check the month and the year
                    if (expense.Date.Month == month && expense.Date.Year == year)
                    {
                        //if it matches add the amount to the yearly total
                        monthly_total += expense.Amount;
                    }
                }
            }
            // round the total to 2 decimals and return
            return Math.Round(monthly_total, 2);
        }
        /// <summary>
        /// calculate the yearly income for a specified year
        /// </summary>
        /// <param name="year">the year specified</param>
        /// <returns>the total annual Income for specified year</returns>
        public static double CalculateIncome(User user,int year)
        {
            //set yearly total to 0
            double yearly_total = 0;
            // loop through users statements
            foreach(Statement s in user.Statements)
            {
                // check if statement is income
                if(s is Income income){
                    //if it is check the year matches
                    if(income.Date.Year == year)
                    {
                        //if it does add amount to yearly total
                        yearly_total += income.Amount;
                    }
                }
            }
            // round to 2 decimals and return total.
            return Math.Round(yearly_total, 2);
        }
        /// <summary>
        /// calculate the yearly expense for a specified year
        /// </summary>
        /// <param name="year">the year specified</param>
        /// <returns></returns>
        public static double CalculateExpense(User user,int year)
        {
            //set yearly expense to 0
            double yearly_expense = 0;
            //loop through users statements
            foreach(Statement s in user.Statements)
            {
                //check if statement is an expense
                if(s is Expense expense)
                {
                    //if it is check the year matches
                    if(expense.Date.Year == year){
                        //add amount to yearly expense
                        yearly_expense += expense.Amount;
                    }
                }
            }
            // round to 2 decimals and return total
            return Math.Round(yearly_expense, 2);

        }
        /// <summary>
        /// calculate a specified items monthly income for a specified month and year
        /// </summary>
        /// <param name="item">the income source</param>
        /// <param name="month">the month specified</param>
        /// <param name="year">the year specified</param>
        /// <returns>the total specified item income for specific month and year</returns>
        public static double CalculateIncome(User user, string item, int month, int year)
        {
            //still to be implemented
            return 0.00;
        }
        /// <summary>
        /// calculate a specified items expense for a specified month and year
        /// </summary>
        /// <param name="item">the expense item</param>
        /// <param name="month">the month specified</param>
        /// <param name="year">the year specified</param>
        /// <returns></returns>
        public static double CalculateExpense(User user, string item, int month, int year)
        {
            //still to be implemented
            return 0.00;
        }
        public static bool IsValidYear(string strNumber)
        {
            try
            {
                int number = int.Parse(strNumber);
                if (number is < 1900 || number > 9999)
                {
                    throw new Exception("year must be greater than 1900 and less than 9999!");
                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidMonth(string strNumber)
        {
            try
            {
                int number = int.Parse(strNumber);
                if (number <= 0 || number <= 12)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Month must be between 1 - 12 representing the months");
                    
                }
            }
            catch
            {
                return false;
            }
    }
    }
}
