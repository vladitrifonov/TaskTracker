using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Dapper
{
    //public interface IDapperConfiguration
    //{
    //    string GetSelectQuery();
    //    string GetSelectByIdQuery();
    //    string GetCreateQuery();
    //    string GetUpdateQuery();
    //    string GetDeleteQuery();
    //}

    public abstract class DapperConfiguration
    {
        private readonly string _table;
        private readonly CommonHelper _helper;
        public DapperConfiguration(string table, CommonHelper helper)
        {
            _table = table;
            _helper = helper;
        }
        public string GetSelectQuery()
        {
            return $"SELECT * FROM {_table}";
        }

        public string GetSelectByIdQuery()
        {
            return $"SELECT * FROM {_table} WHERE Id = @id";
        }

        public string GetCreateQuery()
        {
            string insertQuery = _helper.GenerateCreateValuesQuery();
            return $"INSERT INTO {_table} {insertQuery}";
        }

        public string GetUpdateQuery()
        {
            string updateQuery = _helper.GenerateUpdateValuesQuery();
            return $"UPDATE {_table} SET {updateQuery} WHERE Id = @Id";
        }

        public string GetDeleteQuery()
        {
            return $"DELETE FROM {_table} WHERE Id = @id";
        }
    }
}
