using BussiensLayer.Concrete;
using BussiensLayer.ValidationRules;
using DataAccessLAyer.Concrete;
using DataAccessLAyer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers.WriterPanel
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            return View(mm.GetListInbox(p));
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            return View(mm.GetListSendbox(p));
        }
        public PartialViewResult MessageListMenu()
        {
            string p = (string)Session["WriterMail"];
            Context c = new Context();
            ViewBag.d1 = c.Message.Where(x => x.ReceiverMail == p).Select(x => x.MessageID).Count();
            ViewBag.d2 = c.Message.Where(x => x.SenderMail == p).Select(x => x.MessageID).Count();
            return PartialView();
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = sender;
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
    }
}