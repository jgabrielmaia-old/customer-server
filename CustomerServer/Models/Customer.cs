using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerServer.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("birth")]
        public string Birth { get; set; }

        [BsonElement("firstOrder")]
        public string FirstOrder { get; set; }

        [BsonElement("orderCount")]
        public string OrderCount { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("street")]
        public string Street { get; set; }

        [BsonElement("streetNumber")]
        public string StreetNumber { get; set; }

        [BsonElement("detail")]
        public string Detail { get; set; }
    }
}
