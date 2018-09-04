using System.Data;

namespace Reminders.Data.Repository.Interfaces
{
    public interface ISqlProvider
    {
        IDbConnection Connection { get; }
    }
}