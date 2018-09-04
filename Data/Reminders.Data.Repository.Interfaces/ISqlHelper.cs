namespace Reminders.Data.Repository.Interfaces {
    public interface ISqlHelper<in T>
    {
        string GetAllSql { get; }
        string GetByIdSql { get; }
        string CreateSql { get; }
        string UpdateSql { get; }
        string DeleteSql { get; }
        object GetCreateParams(T obj);
        object GetUpdateParams(T obj);
    }
}