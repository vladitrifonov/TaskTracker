namespace TaskTracker.Infrastructure.MongoDb.Configuration
{
    public class TaskMongoDbConfiguration : IMongoDbConfiguration
    {
        public string GetCollectionName()
        {
            return "Tasks";
        }
    }
}
