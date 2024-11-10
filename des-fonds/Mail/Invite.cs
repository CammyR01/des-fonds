using des_fonds.Users;

namespace des_fonds.Mail
{
    public class Invite : Message
    {
        private string status;
        public string Status { get => status; set => status = value; }

        public Invite(DateTime createdAt, User partyA, User partyB, string message_text) : base(createdAt, partyA, partyB, message_text)
        {
            this.status = "Pending";

        }

        public void Accept()
        {
            this.status = "Accepted";
            base.Message_Text = $"thanks for the invite i have accepted it\nMessage status currently: '{status}'";
            UserManager.ReturnAcceptInvite(this);


        }
        public void Decline()
        {
            this.status = "Declined";
            this.Message_Text = "thanks for the invite, but sorry i decline";
            //UserManager.ReturnDeclineInvite(this);
        }
        public string SendingInvite()
        {
            base.Message_Text = string.Format("{0} has sent you an invite to join there household at", PartyA.Uname);
            base.Message_Text += $"\n{PartyA.Address}";
            base.Message_Text += $"\n\n{Message_Text}";
            base.Message_Text += $"\nMessage status currently: '{status}'.";
            return base.Message_Text;
        }
        public string ReturnInvite()
        {
            return base.Message_Text = string.Format("{0} has accepted your invite and joined your household\nMessage Status: {1}",
                PartyB.Uname, status);
        }

        public override string ToString()
        {
            return base.Message_Text;
        }
    }
}
