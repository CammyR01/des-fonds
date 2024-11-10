using des_fonds.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Users
{
    public class Household
    {
        private List<User> members;
        private User head;

        public List<User> Members { get => members; set => members = value; }
        public User Head { get => head; set => head = value; }

        public Household(User user)
        {
            this.head = user;
            members = new List<User>();
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
        //remove Members

            //share bills

        public override string ToString()
        {
            string strout = "The house head is:" + head.Uname;
            return strout;
        }
        
        
    }
}
