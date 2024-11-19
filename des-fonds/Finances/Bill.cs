using des_fonds.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Finances
{
    public class Bill:Statement
    {
        private Status status;

        private string billName;
  
        public string BillName { get => billName; set => billName= value; }
        public Status Status { get => status; set => status = value; }


        public Bill(string billName, Status status,double amount, DateTime dueDate):base(amount,dueDate)
        {
            this.billName = billName;
            this.status = status;

        }



        public override string ToString()
        {
            string strout = string.Format("Bill Id: {0}\n" +
                "Bill Name: {1}\n" +
                "Amount: £{2}\n" +
                "Due Date: {3}\n"
             
                , Id, billName, Amount, Date.ToShortDateString());
            return strout;
        }
    }
    public enum Status
    {
        Paid,
        Pending
    }
}
