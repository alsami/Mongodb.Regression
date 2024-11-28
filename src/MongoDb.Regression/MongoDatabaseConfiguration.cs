using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace MongoDb.Regression
{
    public static class MongoDatabaseConfiguration
    {
        public static void ConfigureDatabase()
        {
            var conventionPack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String),
            };

            BsonSerializer.RegisterSerializationProvider(new UtcDateTimeSerializationProvider());
            BsonSerializer.RegisterSerializationProvider(new GuidSerializationProvider());
        
            ConventionRegistry.Register(nameof(IgnoreExtraElementsConvention), conventionPack, _ => true);    
            ConventionRegistry.Register(nameof(CamelCaseElementNameConvention), conventionPack, _ => true);
            ConventionRegistry.Register(nameof(EnumRepresentationConvention), conventionPack, _ => true);
        }
    }
}