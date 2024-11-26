﻿using des_fonds.Controller;
using des_fonds.Finances;
using des_fonds.Mail;
using Org.BouncyCastle.Pqc.Crypto.Bike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Users
{
    public class Household
    {
        private int id;
        private int user_id;
        private int mem1_id;
        private int mem2_id;
        private int mem3_id;
        private int mem4_id;
        private int mem5_id;
        private int mem6_id;
        private int bill_id;

        //may no longer be needed
        private List<User>? members = new List<User>();
        private User? head;
        private List<Bill>? bills;

        public List<User>? Members { get => members; set => members = value; }
        public User? Head { get => head; set => head = value; }
        public List<Bill>? Bills { get => bills; set => bills = value; }
        public int Id { get => id; set => id = value; }
        public int User_id { get => user_id; set => user_id = value; }

        public int Bill_id { get => bill_id; set => bill_id = value; }

        public Household(User user)
        {
            this.head = user;
            members = new List<User>();
            bills = new List<Bill>();
        }
        public Household(int id, int user_id, int mem1_id, int mem2_id, int mem3_id, int mem4_id, int mem5_id, int mem6_id, int bill_id)
        {
            this.id = id;
            this.user_id = user_id;
            
            this.bill_id = bill_id;
        }
        public Household(int id, int user_id, List<User> members)
        {
            this.id = id;
            this.user_id = user_id;
            this.members = members;
        }



        //send invite to member to join household
        public void SendInvite(User head, string username, string message)
        {
            try
            {
                UserManager.SendInvite(head, username, message);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool RemoveBill(Bill bill)
        {
            if (bill != null && bills.Contains(bill))
            {
                bills.Remove(bill);
                return true;
            }
            return false;
        }


        //public static List<Bill> Last5Bills(User user)
        //{
        //    Household house = DataController.GetHousehold(user);

            
        //}

        //share bills

        public override string ToString()
        {
            string strout = "The house head is:" + head.Uname;
            return strout;
        }
        
        
    }
}
