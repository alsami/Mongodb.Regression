using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace MongoDb.Regression
{
    public class UtcDateTimeSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer? GetSerializer(Type type)
        {
            return type == typeof(DateTime) ? new DateTimeSerializer(DateTimeKind.Utc, BsonType.Document) : null;
        }
    }
}