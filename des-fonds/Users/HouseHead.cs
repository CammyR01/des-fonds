using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace des_fonds.Users
{
    public class HouseHead
    {
        private List<User> members;
        private User head;

        public HouseHead(User user)
        {
            this.head = user;
            members = new List<User>();
        }

        //add member to members list if invite is accepted
        public void addHouseMember(User user)
        {
            members.Add(user);
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
