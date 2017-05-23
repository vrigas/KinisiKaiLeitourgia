using KinisiKaiLeitourgeia.Models;
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
                var people = _context.People.ToList();
                return View("LoggedInView", people);
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