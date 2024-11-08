using des_fonds.Users;

namespace des_fonds.Mail
{
    public class Invite : Message
    {
        private string status;
        public string Status { get => status; set => status = value; }

        public Invite(DateTime createdAt, User partyA, User partyB, string message_text):base(createdAt, partyA, partyB, message_text)
        {
            this.status = "Pending";

        }

        public void Accept()
        {
            this.status = "Accepted";
        }
        public void Decline()
        {
            this.status = "Declined";
        }

        public override string ToString()
        {
            string strout = string.Format("{0} has sent you an invite to join there household at",PartyA.Uname);
            strout += $"\n{PartyA.Address}";
            strout += $"\n\n{Message_Text}";
            strout += $"\nMessage status currently: '{status}'.";
            return strout;
        }
    }
}
