using System.Diagnostics;
using MongoDB.Driver;
using MongoDb.Regression;

MongoDatabaseConfiguration.ConfigureDatabase();
const string connectionString = "mongodb://mongoadmin:<Your password here>@127.0.0.1:27017?authSource=admin";
const string databaseName = "RegressionDatabase";
const string collectionName = "data";

var mongoUrl = MongoUrl.Create(connectionString);
var mongoClient = new MongoClient(mongoUrl);
var database = mongoClient.GetDatabase(databaseName);

var data = new Data(
    Guid.NewGuid(), 
    new Dictionary<string, object> { ["GuidKey"] = Guid.NewGuid() });

var collection = database.GetCollection<Data>(collectionName);
await collection.InsertOneAsync(data);

var readData = await collection
    .Find(d => d.Id == data.Id)
    .SingleAsync();
    
Debug.Assert(readData.Id == data.Id);