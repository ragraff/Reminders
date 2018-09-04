using System.Collections.Generic;
using System.Data;

namespace Reminders.Data.Repository.Interfaces {
    public interface ISqlMapperWrapper
    {
        IEnumerable<T> Query<T>(IDbConnection connection, string sql, object sqlParams = null);
        void Execute(IDbConnection connection, string sql, object sqlParams);
    }
}