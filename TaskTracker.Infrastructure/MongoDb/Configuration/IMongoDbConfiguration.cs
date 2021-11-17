namespace TaskTracker.Infrastructure.MongoDb.Configuration
{
    public interface IMongoDbConfiguration
    {
        string GetCollectionName();
    }
}
