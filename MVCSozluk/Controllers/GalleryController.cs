using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSozluk.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageManager im = new ImageManager(new EfImageDal());
        public ActionResult Index()
        {
            var imagevalues = im.GetList();
            return View(imagevalues);
        }
    }
}