using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSozluk.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByWriter(id);
            return PartialView(contentlist);
        }
        public ActionResult Headings()
        {
            var headings = hm.GetList();
            return View(headings);
        }
    }
}