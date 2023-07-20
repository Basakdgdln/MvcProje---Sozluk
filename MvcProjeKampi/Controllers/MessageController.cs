using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
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

    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        [HttpGet]
        public ActionResult Inbox()
        {
            string p = (string)Session["AdminUserName"];
            return View(mm.GetListInbox(p).ToList());
        }

        [HttpPost]
        public ActionResult Inbox(string p)
        {
            var result = (from x in mm.AllMessage() select x);
            if (!string.IsNullOrEmpty(p))
            {
                result = result.Where(x => x.SenderMail.Contains(p) || x.ReceiverMail.Contains(p) || x.Subject.Contains(p) || x.MessageContent.Contains(p));
            }
            return View(result.ToList());
        }

        [HttpGet]
        public ActionResult Sendbox()
        {
            string p = (string)Session["AdminUserName"];
            return View(mm.GetListSendbox(p));
        }

        [HttpPost]
        public ActionResult Sendbox(string p)
        {
            var result = from x in mm.AllMessage() select x;
            if (!string.IsNullOrEmpty(p))
            {
                result = result.Where(x => x.SenderMail.Contains(p) || x.ReceiverMail.Contains(p) || x.Subject.Contains(p) || x.MessageContent.Contains(p));
            }
            return View(result.ToList());
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
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
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messagevalues = mm.GetByID(id);
            return View(messagevalues);
        }
    }
}
