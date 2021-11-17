namespace TaskTracker.Infrastructure.MongoDb.Configuration
{
    public class ProjectMongoDbConfiguration : IMongoDbConfiguration
    {
        public string GetCollectionName()
        {
            return "Projects";
        }
    }
}
