using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDb.Regression
{
    public class GuidSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer? GetSerializer(Type type)
        {
            return type == typeof(Guid) ? new GuidSerializer(BsonType.String) : null;
        }
    }
}