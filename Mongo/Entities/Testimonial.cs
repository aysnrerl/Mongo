using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string NameSurname { get; set; }
        public string Pozition { get; set; }
    }
}
