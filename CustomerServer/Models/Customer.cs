using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerServer.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string FirstOrder { get; set; }

        public string OrderCount { get; set; }

        public string Phone { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string Detail { get; set; }
    }
}
