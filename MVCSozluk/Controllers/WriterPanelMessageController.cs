using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSozluk.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            Context c = new Context();
            string p = (string)Session["WriterMail"];
            var writermailinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageBox()
        {
            var deger1 = mm.GetList().Count();
            ViewBag.dgr1 = deger1;
            return PartialView();
        }
        public ActionResult Inbox2()
        {
            Context c = new Context();
            string p = (string)Session["WriterMail"];
            var writermailinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var messagelist = mm.GetListSendBox(p);
            return View(messagelist);
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            Context c = new Context();
            string d = (string)Session["WriterMail"];
            var writermailinfo = c.Writers.Where(x => x.WriterMail == d).Select(y => y.WriterID).FirstOrDefault();
            p.SenderMail = d;
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.MessageAdd(p);
            return RedirectToAction("Inbox2");
        }

    }
}