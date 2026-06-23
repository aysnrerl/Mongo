using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class SSS
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SSSId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
