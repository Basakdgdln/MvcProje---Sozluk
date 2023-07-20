using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            return View(adm.GetList());
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> role = (from x in adm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.AdminRole,
                                             Value = x.AdminRole
                                         }).ToList();
            ViewBag.d1 = role;
            return View(adm.GetList());
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adm.AdminAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> role = (from x in adm.GetList()
                                         select new SelectListItem
                                         {
                                             Text = x.AdminRole,
                                             Value = x.AdminRole
                                         }).ToList();
            ViewBag.d1 = role;
            return View(adm.GetByID(id));
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            adm.AdminUpdate(p);
            return RedirectToAction("Index");
        }

    }
}