using BussiensLayer.Concrete;
using DataAccessLAyer.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {

        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index(int sayfa = 1)
        {
            return View(ifm.GetList().ToPagedList(sayfa, 12));
        }
    }
}