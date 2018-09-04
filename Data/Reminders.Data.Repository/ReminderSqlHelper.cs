using Reminders.Data.Repository.Interfaces;
using Reminders.Models.Domain;

namespace Reminders.Data.Repository.SqlServer
{
    public class ReminderSqlHelper : ISqlHelper<Reminder>
    {
        public string GetAllSql => "SELECT * FROM Reminder;";
        public string GetByIdSql => $"SELECT * FROM Reminder WHERE Id = @{nameof(Reminder.Id)}";
        public string CreateSql => $"INSERT INTO Reminder (Text,Priority,DueDate) VALUES (@{nameof(Reminder.Text)},@{nameof(Reminder.Priority)},@{nameof(Reminder.DueDate)})";
        public string UpdateSql => $"UPDATE Reminder SET Text = @{nameof(Reminder.Text)},Priority=@{nameof(Reminder.Priority)},DueDate=@{nameof(Reminder.DueDate)} WHERE Id=@{nameof(Reminder.Id)}";
        public string DeleteSql => $"DELETE FROM Reminder WHERE id = @{nameof(Reminder.Id)}";

        public object GetCreateParams(Reminder reminder)
        {
            return new {reminder.Text, reminder.Priority,reminder.DueDate};
        }

        public object GetUpdateParams(Reminder reminder)
        {
            return new {reminder.Id, reminder.Text, reminder.Priority, reminder.DueDate};
        }
    }
}