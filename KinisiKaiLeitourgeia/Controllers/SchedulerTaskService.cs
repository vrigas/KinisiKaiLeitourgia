using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using KinisiKaiLeitourgeia.Models.Appointments;
using KinisiKaiLeitourgeia.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace KinisiKaiLeitourgeia.Controllers
{

    public class SchedulerTaskService : ISchedulerEventService<Appointment>
    {
        private static bool UpdateDatabase = true;
        private ApplicationDbContext db;

        public SchedulerTaskService(ApplicationDbContext context)
        {
            db = context;
        }

        public SchedulerTaskService()
            : this(new ApplicationDbContext())
        {
        }

        public virtual IList<Appointment> GetAll()
        {
            bool IsWebApiRequest = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/api");
            IList<Appointment> result = null;

            if (!IsWebApiRequest)
            {
                result = HttpContext.Current.Session["SchedulerTasks"] as IList<Appointment>;
            }

            if (result == null || UpdateDatabase)
            {
                result = db.Appointments
                    .ToList().Select(task => new Appointment
                    {
                        TaskID = task.TaskID,
                        Title = task.Title,
                        Start = DateTime.SpecifyKind(task.Start, DateTimeKind.Utc),
                        End = DateTime.SpecifyKind(task.End, DateTimeKind.Utc),
                        StartTimezone = task.StartTimezone,
                        EndTimezone = task.EndTimezone,
                        Description = task.Description,
                        IsAllDay = task.IsAllDay,
                        RecurrenceRule = task.RecurrenceRule,
                        RecurrenceException = task.RecurrenceException,
                        AppointmentPlaceId = task.AppointmentPlaceId,
                        TherapistId = task.TherapistId,
                        PatientId = task.PatientId,
                        Price = task.Price,
                        Balance = task.Balance,
                        TypeAppointmentId = task.TypeAppointmentId
                    }).ToList();

                if (!IsWebApiRequest)
                {
                    HttpContext.Current.Session["SchedulerTasks"] = result;
                }
            }

            return result;
        }

        public virtual void Insert(Appointment task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (!UpdateDatabase)
                {
                    var first = GetAll().OrderByDescending(e => e.TaskID).FirstOrDefault();
                    var id = (first != null) ? first.TaskID : 0;

                    task.TaskID = id + 1;

                    GetAll().Insert(0, task);
                }
                else
                {
                    if (string.IsNullOrEmpty(task.Title))
                    {
                        task.Title = "";
                    }
                    task.Title = db.Patients.Find(task.PatientId).FullName + " - " + db.Therapists.Find(task.TherapistId).Surname;
                    task.Balance = task.Price;
                    var entity = task;

                    db.Appointments.Add(entity);
                    db.SaveChanges();
                    task.TaskID = entity.TaskID;
                }
            }
        }

        public virtual void Update(Appointment task, ModelStateDictionary modelState)
        {
            if (ValidateModel(task, modelState))
            {
                if (!UpdateDatabase)
                {
                    var target = One(e => e.TaskID == task.TaskID);

                    if (target != null)
                    {
                        target.Title = task.Title;
                        target.Start = task.Start;
                        target.End = task.End;
                        target.StartTimezone = task.StartTimezone;
                        target.EndTimezone = task.EndTimezone;
                        target.Description = task.Description;
                        target.IsAllDay = task.IsAllDay;
                        target.RecurrenceRule = task.RecurrenceRule;
                        target.RecurrenceException = task.RecurrenceException;
                        target.TherapistId = task.TherapistId;
                        target.PatientId = task.PatientId;
                        target.AppointmentPlaceId = task.AppointmentPlaceId;
                        
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(task.Title))
                    {
                        task.Title = "";
                    }
                    db.Appointments.Attach(task);
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        public virtual void Delete(Appointment task, ModelStateDictionary modelState)
        {
            if (!UpdateDatabase)
            {
                var target = One(p => p.TaskID == task.TaskID);
                if (target != null)
                {
                    GetAll().Remove(target);

                    //var recurrenceExceptions = GetAll().Where(m => m.RecurrenceID == task.TaskID).ToList();

                    //foreach (var recurrenceException in recurrenceExceptions)
                    //{
                    //    GetAll().Remove(recurrenceException);
                    //}
                }
            }
            else
            {
                var entity = task;
                db.Appointments.Attach(entity);

                //var recurrenceExceptions = db.Appointments.Where(t => t.RecurrenceID == task.TaskID);

                //foreach (var recurrenceException in recurrenceExceptions)
                //{
                //    db.Tasks.Remove(recurrenceException);
                //}

                db.Appointments.Remove(entity);
                db.SaveChanges();
            }
        }

        private bool ValidateModel(Appointment appointment, ModelStateDictionary modelState)
        {
            if (appointment.Start > appointment.End)
            {
                modelState.AddModelError("errors", "End date must be greater or equal to Start date.");
                return false;
            }

            return true;
        }

        public Appointment One(Func<Appointment, bool> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            db.Dispose();
        }

        IQueryable<Appointment> ISchedulerEventService<Appointment>.GetAll()
        {
            return db.Appointments;
        }
    }
}