using DataAccessLAyer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class statisticsController : Controller
    {
        // GET: statistics
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.TotalCategory = c.Categories.Count();
            ViewBag.Heading = c.Headings.Where(p => p.CategoryID == 12).Count();
            ViewBag.writer = c.Writers.Where(p => p.WriterName.Contains("a")).Count();


            return View();
        }
    }
}