using System;
using System.ComponentModel.DataAnnotations;

namespace Reminders.Models.Domain
{
    public class Reminder
    {
        public string Text { get; set; }
        public long Id { get; set; }
        public Priority Priority { get; set; }

        [DisplayFormat(DataFormatString="{0:d}")]
        public DateTime? DueDate { get; set; }
    }
}