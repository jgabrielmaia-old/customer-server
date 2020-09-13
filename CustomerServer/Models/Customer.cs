using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace CustomerServer.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("birth")]
        [JsonProperty("birth")]
        public string Birth { get; set; }

        [BsonElement("firstOrder")]
        [JsonProperty("firstOrder")]
        public string FirstOrder { get; set; }

        [BsonElement("orderCount")]
        [JsonProperty("orderCount")]
        public string OrderCount { get; set; }

        [BsonElement("phone")]
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [BsonElement("neighborhood")]
        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("street")]
        [JsonProperty("street")]
        public string Street { get; set; }

        [BsonElement("streetNumber")]
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }

        [BsonElement("detail")]
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
