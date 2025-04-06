using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class PersonWithAddress
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }
}