using System;
using System.Web.Mvc;
using Reminders.Data.Repository.Interfaces;
using Reminders.Models.Domain;

namespace Reminders.UI.Mvc.Controllers
{
    public class ReminderController : Controller
    {
        private readonly IRepository<Reminder> _reminderRepo;

        public ReminderController(IRepository<Reminder> reminderRepo)
        {
            _reminderRepo = reminderRepo;
        }

        // GET: Reminder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _GetAll()
        {
            try
            {
                var reminders = _reminderRepo.GetAll();
                return PartialView("_GetAll", reminders);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public ActionResult _Create()
        {
            return PartialView("_Create");
        }

        public ActionResult Create(Reminder reminder)
        {
            _reminderRepo.Create(reminder);

            return RedirectToAction("Index");
        }

        public ActionResult _Update(long id)
        {
            var edit = _reminderRepo.Get(id);

            return View("_Update", edit);
        }

        public ActionResult Update(Reminder reminder)
        {
            _reminderRepo.Update(reminder);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            _reminderRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}