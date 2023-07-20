using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index(int page = 1)
        {
            return View(hm.GetList().ToPagedList(page, 10));
        }

        public ActionResult HaedingReport()
        {
            return View(hm.GetList());
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.d1 = valuecategory;
            ViewBag.d2 = valuewriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.d1 = valuecategory;
            ViewBag.d2 = valuewriter;
            var headingvalue = hm.GetByID(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading h)
        {
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingUpdate(h);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetByID(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
            }
            else
            {
                headingvalue.HeadingStatus = true;
            }
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }

        public ActionResult HeadingReport()
        {
            return View(hm.GetList());
        }

    }
}