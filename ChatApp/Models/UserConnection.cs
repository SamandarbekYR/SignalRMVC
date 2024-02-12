namespace ChatApp.Models
{
    public class UserConnection
    {
        public string FullName { get; set; }
        public string ConnectionId { get; set; }
        public bool IsOnline { get; set; } = false;
    }
}
