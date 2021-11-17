namespace TaskTracker.Domain.Configuration.MongoDbConfiguration
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
