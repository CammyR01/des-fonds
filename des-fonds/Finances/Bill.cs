using des_fonds.Users;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Finances
{
    public class Bill
    {
        private Status status;
        private double amount;
        private DateTime dueDate;
        private string billName;

        public Status Status { get => status; set => status = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public string BillName { get => billName; set => billName = value; }

        public Bill(string billName, Status status,double amount, DateTime dueDate)
        {
            this.billName = billName;
            this.status = status;
            this.dueDate = dueDate;
            this.amount = amount;

        }
        public Bill(Status editedStatus)
        {
            this.status = editedStatus;
        }



        public override string ToString()
        {
            string strout = string.Format(
                "Bill Name: {0}\n" +
                "Amount: £{1}\n" +
                "Due Date: {2}\n"+
                "Status: {3}\n"
             
                , billName, amount, dueDate.ToShortDateString(), status);
            return strout;
        }
    }
    public enum Status
    {
        Paid,
        Pending
    }
}
