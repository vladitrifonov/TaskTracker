using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Configuration.MongoDbConfiguration;
using TaskTracker.Domain.Contracts;
using TaskTracker.Infrastructure.MongoDb;
using TaskTracker.Infrastructure.MongoDb.Configuration;

namespace TaskTracker.Infrastructure.Services
{
    public class MongoDbRepository<T> : IRepository<T> where T : BaseEntity/*, IDocument*/
    {
        private readonly IMongoCollection<T> _collection;

        public MongoDbRepository(IMongoDbSettings settings, IMongoDbConfiguration configuration)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(configuration.GetCollectionName());
        }
        public Task<IEnumerable<T>> GetAsync()
        {
            return Task.FromResult(_collection.AsQueryable().AsEnumerable());
        }

        //public async Task<IEnumerable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
        //{
        //    var collection = await _collection.FindAsync(predicate);
        //    return collection.ToEnumerable();
        //}

        public async Task<T> GetByIdAsync(int id)
        {
            IAsyncCursor<T> collection = await _collection.FindAsync(x => x.Id == id);
            return await collection.FirstOrDefaultAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, entity.Id);
            await _collection.FindOneAndReplaceAsync(filter, entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //var objectId = new ObjectId(entity.Id);
            //FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, objectId);
            await _collection.FindOneAndDeleteAsync(x => x.Id == entity.Id);
        }         
    }
}
