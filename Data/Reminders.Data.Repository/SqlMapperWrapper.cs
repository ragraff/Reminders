using System.Collections.Generic;
using System.Data;
using Dapper;
using Reminders.Data.Repository.Interfaces;

namespace Reminders.Data.Repository.SqlServer
{
    public class SqlMapperWrapper : ISqlMapperWrapper
    {
        public IEnumerable<T> Query<T>(IDbConnection connection, string sql, object sqlParams = null)
        {
            return connection.Query<T>(sql, sqlParams);
        }

        public void Execute(IDbConnection connection, string sql, object sqlParams)
        {
            connection.Execute(sql, sqlParams);
        }
    }
}