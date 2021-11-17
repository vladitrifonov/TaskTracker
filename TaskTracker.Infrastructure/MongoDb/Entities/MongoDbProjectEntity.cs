using MongoDB.Bson;
using System;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.MongoDb.Entities
{
    [BsonCollection("Projects")]
    public class MongoDbProjectEntity : ProjectEntity, IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
