using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSozluk.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Inbox2(string p)
        {
            var messagelist = mm.GetListSendBox(p);
            return View(messagelist);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            p.SenderMail = "admin@gmail.com";
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(p);
            return RedirectToAction("Inbox2");
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var cmvalues = mm.GetByID(id);
            return View(cmvalues);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var cmvalues = mm.GetByID(id);
            return View(cmvalues);
        }
    }
}