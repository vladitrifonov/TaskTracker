using NUnit.Framework;
using System;
using System.Linq.Expressions;
using TaskTracker.Contracts.Entities;
using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            GetByPredicateAsync(x => x.Id == 2);

            //var projectHelper = new ProjectHelper(new ProjectEntity());

            //var create = projectHelper.GenerateCreateValuesQuery();

            //var update = projectHelper.GenerateCreateValuesQuery();
        }

        private void GetByPredicateAsync(Expression<Func<ProjectEntity, bool>> predicate)
        {
            var body = predicate.Body as BinaryExpression;
            var left = body?.Left as MemberExpression;
            var right = body?.Right as ConstantExpression;

            string name = left?.Member?.Name;
            string value = right?.Value?.ToString();
            var qweqwe = 2;
        }
    }
}