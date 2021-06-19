using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StoneEntrevista.Infra.Data.Context;

namespace StoneEntrevista.Infra.Data.Config
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase = null;

        public MongoDbContext(IOptions<MongoConnectionConfig> mongoConnectionConfig)
        {
            MongoClient mongoClient = new MongoClient(mongoConnectionConfig.Value.ConnectionString);

            if (mongoClient != null)
            {
                System.Console.WriteLine($"Connected to MongoDB. Trying to reach the database: {mongoConnectionConfig.Value.Database}.");
                _mongoDatabase = mongoClient.GetDatabase(mongoConnectionConfig.Value.Database);
                if (_mongoDatabase != null)
                {
                    System.Console.WriteLine("Succefully connected to database.");
                }
            }
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            System.Console.WriteLine($"Trying to reach collection: {typeof(T).Name}");
            return _mongoDatabase.GetCollection<T>(typeof(T).Name);
        }
    }
}