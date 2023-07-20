using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.Abstract;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            return View(wm.GetList());
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer w)
        {
            ValidationResult result = writervalidator.Validate(w);
            if (result.IsValid)
            {
                wm.WriterAdd(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = wm.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult WriterHeading(int id)
        {
            HeadingManager hm = new HeadingManager(new EfHeadingDal());
            var value = wm.GetByID(id);
            var heading = hm.GetListByWriter(value.WriterID).ToList();
            return View(heading);
        }

    }
}