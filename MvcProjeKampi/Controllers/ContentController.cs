using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                return View(cm.GetList(" "));
            }
            return View(cm.GetList(p));
        }

        public ActionResult ContentByHeading(int id)
        {
            return View(cm.GetListByHeadingID(id));
        }
    }
}