using ChatApp.Models;
using MongoDB.Driver;

namespace ChatApp.DataAccessLayer.Data
{
    public class AppDbContext
    {  
        public IMongoDatabase Database { get; set; }
        public AppDbContext(string connectionString, string database)
        {
            var connection = new MongoClient(connectionString);
            Database = connection.GetDatabase(database);  
        }

        public IMongoCollection<Users> User =>
            Database.GetCollection<Users>("Users");
    }
}
