using des_fonds.Users;
namespace des_fonds.Mail
{
    public class Message
    {
        private DateTime createdAt;
        private User partyA;
        private User partyB;
        private string message_text = "";

        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public User PartyA { get => partyA; set => partyA = value; }
        public User PartyB { get => partyB; set => partyB = value; }
        public string Message_Text { get => message_text; set => message_text = value; }

        public Message(DateTime createdAt, User partyA, User partyB, string message_text)
        {
            this.createdAt = createdAt;
            this.partyA = partyA;
            this.partyB = partyB;
            this.message_text = message_text;
        }

        public override string ToString()
        {
            return message_text;
        }
    }
}
