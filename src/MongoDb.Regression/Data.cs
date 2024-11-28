namespace MongoDb.Regression;

public record Data(Guid Id, IReadOnlyDictionary<string, object> Properties);