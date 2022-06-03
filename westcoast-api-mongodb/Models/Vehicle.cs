using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace westcoast_api_mongodb.Models
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("regNo")]
        public string? RegNo { get; set; }
        [BsonElement("make")]
        public string? Make { get; set; }
        [BsonElement("model")]
        public string? Model { get; set; }
    }
}
