using System.Collections.Generic;
using System.Linq;
using Reminders.Data.Repository.Interfaces;

namespace Reminders.Data.Repository.SqlServer
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ISqlProvider _sqlProvider;
        private readonly ISqlMapperWrapper _sqlMapperWrapper;
        private readonly ISqlHelper<T> _sqlHelper;

        public Repository(ISqlProvider sqlProvider, ISqlMapperWrapper sqlMapperWrapper, ISqlHelper<T> sqlHelper)
        {
            _sqlProvider = sqlProvider;
            _sqlMapperWrapper = sqlMapperWrapper;
            _sqlHelper = sqlHelper;
        }


        public IEnumerable<T> GetAll()
        {
            using (var connection = _sqlProvider.Connection)
            {
                connection.Open();
                return _sqlMapperWrapper.Query<T>(connection, _sqlHelper.GetAllSql);
            }
        }

        public T Get(long id)
        {
            using (var connection = _sqlProvider.Connection)
            {
                connection.Open();
                return _sqlMapperWrapper.Query<T>(connection, _sqlHelper.GetByIdSql, new {id}).FirstOrDefault();
            }
        }

        public void Create(T obj)
        {
            using (var connection = _sqlProvider.Connection)
            {
                connection.Open();
                _sqlMapperWrapper.Execute(connection, _sqlHelper.CreateSql, _sqlHelper.GetCreateParams(obj));
            }
        }

        public void Update(T obj)
        {
            using (var connection = _sqlProvider.Connection)
            {
                connection.Open();
                _sqlMapperWrapper.Execute(connection, _sqlHelper.UpdateSql, _sqlHelper.GetUpdateParams(obj));
            }
        }

        public void Delete(long id)
        {
            using (var connection = _sqlProvider.Connection)
            {
                connection.Open();
                _sqlMapperWrapper.Execute(connection, _sqlHelper.DeleteSql, new {id});
            }
        }
    }
}