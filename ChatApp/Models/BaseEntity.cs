using MongoDB.Bson.Serialization.Attributes;

namespace ChatApp.Models
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
    }
}
