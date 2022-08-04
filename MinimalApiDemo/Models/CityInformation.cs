using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalApiDemo.Models
{
    public class CityInformation
    {
        [BsonId]
        
        public string Id { get; set; }

        [BsonElement("postCode")]
            public string PostCode { get; set; }

            [BsonElement("country")]
            public string Country { get; set; }

            [BsonElement("countryAbbreviation")]
            public string CountryAbbreviation { get; set; }

            [BsonElement("places")]
            public List<Place> Places { get; set; }
        


    }
    public class Place
    {
        [BsonElement("placeNname")]
        public string PlaceName { get; set; }

        [BsonElement("longitude")]
        public string Longitude { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("stateAbbreviation")]
        public string StateAbbreviation { get; set; }

        [BsonElement("latitude")]
        public string Latitude { get; set; }
    }
}
