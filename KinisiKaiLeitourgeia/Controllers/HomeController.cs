using KinisiKaiLeitourgeia.Models;
using KinisiKaiLeitourgeia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KinisiKaiLeitourgeia.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            this._context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var schedulerViewModel = new SchedulerViewModel()
                {
                    AppointmentPlaces = _context.AppointmentPlaces.ToList(),
                    Patients = _context.Patients.ToList(),
                    Therapists = _context.Therapists.ToList()
                };
                return View("LoggedInView", schedulerViewModel);
            }
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}