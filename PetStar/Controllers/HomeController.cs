using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStar.Controllers
{
    public class HomeController : Controller
    {
        public IWindsorContainer Container { get; set; }

        //public HomeController(IWindsorContainer container)
        //{
        //    this.Container = container;
        //}
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var a = this.Container;

            return View();
        }
    }
}
