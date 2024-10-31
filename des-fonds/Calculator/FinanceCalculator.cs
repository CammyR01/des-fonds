using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="month">the month in number representation</param>
        /// <param name="year">the year the user specified</param>
        /// <returns>the total income for the specified month and year for all income statements</returns>
        public static double CalculateMonthlyIncome(int month, int year)
        { 
	///wouldnt this take in month and income as parameters instead of year?

            //Still to be implemented
            return 0.00;
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
        public static double CalculateMonthlyExpense(int month, int year)
        {
            //still to be implemented
            return 0.00;
        }
        /// <summary>
        /// calculate the yearly income for a specified year
        /// </summary>
        /// <param name="year">the year specified</param>
        /// <returns>the total annual Income for specified year</returns>
        public static double CalculateAnnualIncome(int year)
        {
            //still to be implemented
            return 0.00;
        }
        /// <summary>
        /// calculate the yearly expense for a specified year
        /// </summary>
        /// <param name="year">the year specified</param>
        /// <returns></returns>
        public static double CalculateAnnualExpense(int year)
        {
            //still to be implemented
            return 0.00;
        }
        /// <summary>
        /// calculate a specified items monthly income for a specified month and year
        /// </summary>
        /// <param name="item">the income source</param>
        /// <param name="month">the month specified</param>
        /// <param name="year">the year specified</param>
        /// <returns>the total specified item income for specific month and year</returns>
        public static double CalculateItemIncomeMonthly(string item, int month, int year)
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
        public static double CalculateItemExpenseMonthly(string item, int month, int year)
        {
            //still to be implemented
            return 0.00;
        }
    }
}
