using MongoDB.Bson;

namespace SignalRTest.Models
{
    public class Users
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
