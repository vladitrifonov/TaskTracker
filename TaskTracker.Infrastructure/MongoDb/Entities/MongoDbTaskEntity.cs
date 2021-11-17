using MongoDB.Bson;
using System;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.MongoDb.Entities
{
    [BsonCollection("Tasks")]
    public class MongoDbTaskEntity : TaskEntity, IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
