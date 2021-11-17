using MongoDB.Bson;
using System;

namespace TaskTracker.Infrastructure.MongoDb
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;
    }
}
