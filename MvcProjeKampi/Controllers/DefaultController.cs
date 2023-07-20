using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            return View(hm.GetList());
        }
        public PartialViewResult Index(int id = 0)
        {
            return PartialView(cm.GetListByHeadingID(id));
        }

    }
}