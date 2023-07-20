using BussiensLayer.Concrete;
using DataAccessLAyer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {

        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var writermailinfo = c.Writers.Where(x => x.WriterMail == p).Select(s => s.WriterID).FirstOrDefault();
            return View(cm.GetListByWriter(writermailinfo));
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.head = c.Headings.Where(x => x.HeadingID == id).Select(x => x.HeadingName).FirstOrDefault();
            ViewBag.headid = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            var writermailinfo = c.Writers.Where(x => x.WriterMail == mail).Select(s => s.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writermailinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

    }
}