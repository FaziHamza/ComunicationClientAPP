namespace ComunicationClientAPP.Modal
{

    public class Login
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MacAddress { get; set; }
        public virtual ICollection<ChatMessage> ChatMessagesFromUsers { get; set; }
        public virtual ICollection<ChatMessage> ChatMessagesToUsers { get; set; }

        public Login()
        {
            ChatMessagesFromUsers = new HashSet<ChatMessage>();
            ChatMessagesToUsers = new HashSet<ChatMessage>();
        }
    }
}
