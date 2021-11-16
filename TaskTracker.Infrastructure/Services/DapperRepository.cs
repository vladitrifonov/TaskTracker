using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Infrastructure.Dapper;
using System.Linq;
using System.Linq.Expressions;

namespace TaskTracker.Infrastructure.Services
{
    public class DapperRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString;
        private readonly DapperConfiguration _dapperConfiguration;

        public DapperRepository(string connectionString, DapperConfiguration dapperConfiguration)
        {
            _connectionString = connectionString;
            _dapperConfiguration = dapperConfiguration;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<T>(_dapperConfiguration.GetSelectQuery());
            }              
        }

        //works only witn one parameter (preferably Id)
        //public async Task<IEnumerable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
        //{
        //    (string Name, object Value) properties = GetProperties(predicate);
        //    using (IDbConnection db = new SqlConnection(_connectionString))
        //    {
        //        var test = await db.QueryAsync<T>(_dapperConfiguration.GetSelectByPredicateQuery(properties.Name), new { properties.Value });
        //        return await db.QueryAsync<T>(_dapperConfiguration.GetSelectByPredicateQuery(properties.Name), new { properties.Value });
        //    }
        //}

        public async Task<T> GetByIdAsync(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<T> collection = await db.QueryAsync<T>(_dapperConfiguration.GetSelectByIdQuery(), new { id });
                return collection.FirstOrDefault();
            }
        }

        //if we want to get id of added entity
        //var sqlQuery = "INSERT INTO *Table* (*Field1*, *Field2*) VALUES(*@Value1*, *@Value2*); SELECT CAST(SCOPE_IDENTITY() as int)";
        //int? id = db.Query<int>(sqlQuery, *entity*).FirstOrDefault();     
        public async Task<T> CreateAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {             
                await db.ExecuteAsync(_dapperConfiguration.GetCreateQuery(), entity);              
                return entity;
            }
        }

        //should return updated entity
        public async Task<T> UpdateAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {             
                await db.ExecuteAsync(_dapperConfiguration.GetUpdateQuery(), entity);
                return entity;
            }
        }

        public async Task DeleteAsync(T entity)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                await db.ExecuteAsync(_dapperConfiguration.GetDeleteQuery(), new { entity.Id });
            }
        }

        private static (string Name,object Value) GetProperties(Expression<Func<T, bool>> predicate)
        {
            var body = predicate.Body as BinaryExpression;
            var left = body?.Left as MemberExpression;
            var right = body?.Right as ConstantExpression;
            string name = left?.Member?.Name;        
            return (name, right?.Value);
        }
    }
}
