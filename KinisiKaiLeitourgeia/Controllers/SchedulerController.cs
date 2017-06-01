using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using KinisiKaiLeitourgeia.Models;
using KinisiKaiLeitourgeia.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KinisiKaiLeitourgeia.Controllers
{
    public class SchedulerController : ApiController
    {
        SchedulerTaskService service;

        public SchedulerController()
        {
            service = new SchedulerTaskService(new ApplicationDbContext());
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();

            base.Dispose(disposing);
        }

        // GET api/task
        public DataSourceResult Get([System.Web.Http.ModelBinding.ModelBinder(typeof(WebApiDataSourceRequestModelBinder))]DataSourceRequest request)
        {
            return service.GetAll().ToDataSourceResult(request);
        }

        // POST api/task
        public HttpResponseMessage Post(Appointment task)
        {
            if (ModelState.IsValid)
            {
                service.Insert(task, null);

                var response = Request.CreateResponse(HttpStatusCode.Created, new DataSourceResult { Data = new[] { task }, Total = 1 });
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = task.TaskID }));
                return response;
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);

                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        // PUT api/task/5
        public HttpResponseMessage Put(int id, Appointment task)
        {
            task.AppointmentPlace = null;
            task.Therapist = null;
            task.Patient = null;
            task.TypeAppointment = null;
            //if (ModelState.IsValid && id == task.TaskID)
           if (id == task.TaskID)
                {
                try
                {
                    service.Update(task, null);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        // DELETE api/task/5
        public HttpResponseMessage Delete(int id)
        {
            Appointment task = new Appointment
            {
                TaskID = id
            };

            try
            {
                service.Delete(task, null);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, task);
        }
    }
}
