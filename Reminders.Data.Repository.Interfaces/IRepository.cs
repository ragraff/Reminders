using System.Collections.Generic;

namespace Reminders.Data.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Create(T obj);
        void Update(T obj);
        void Delete(long id);
    }
}