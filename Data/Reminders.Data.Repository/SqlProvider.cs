using System.Data;
using Reminders.Data.Repository.Interfaces;

namespace Reminders.Data.Repository.SqlServer
{
    public class SqlProvider : ISqlProvider
    {
        public SqlProvider(IDbConnection connection)
        {
            Connection = connection;
        }

        public IDbConnection Connection { get; }
    }
}