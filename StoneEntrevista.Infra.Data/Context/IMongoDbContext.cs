using MongoDB.Driver;

namespace StoneEntrevista.Infra.Data.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();
    }
}