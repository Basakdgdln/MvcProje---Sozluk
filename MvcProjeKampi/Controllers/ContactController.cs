using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.Concrete;
using DataAccessLAyer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {

        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult Index()
        {
            return View(cm.GetList());
        }

        [HttpPost]
        public ActionResult Index(string p)
        {
            var result = (from x in c.Contacts.ToList() select x);
            if (!string.IsNullOrEmpty(p))
            {
                result = result.Where(x => x.UserName.Contains(p) || x.UserMail.Contains(p) || x.Subject.Contains(p) || x.Message.Contains(p));
            }
            return View(result.ToList());
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["AdminUserName"];
            ViewBag.d1 = c.Contacts.Count();
            ViewBag.d2 = c.Message.Count(x => x.ReceiverMail == p);
            ViewBag.d3 = c.Message.Count(x => x.SenderMail == p);
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }

    }
}