using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using FirstChallenge.Models;

namespace FirstChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(FirstChallenge.Models.ComicBookManager.GetComicBooks());
        }
        public ActionResult Detail(int? id)
        {
            ComicBook comicBook;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            comicBook = ComicBookManager.GetComicBooks().Where(x => x.ComicBookId == id).FirstOrDefault();
            if (comicBook == null)
            {
                return HttpNotFound();
            }

            return View(comicBook);
        }
    }
}