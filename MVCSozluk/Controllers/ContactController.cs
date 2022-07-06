using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSozluk.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public PartialViewResult MessageBox()
        {
            var deger1 = cm.GetList().Count();
            ViewBag.dgr1 = deger1;
            return PartialView();
        }

        public ActionResult GetContactDetails(int id)
        {
            var cmvalues = cm.GetByID(id);
            return View(cmvalues);
        }
    }
}