using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class Subscribe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SubscribeId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
