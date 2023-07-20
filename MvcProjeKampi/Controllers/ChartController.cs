using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(cm.GetList(), JsonRequestBehavior.AllowGet);
        }

    }
}