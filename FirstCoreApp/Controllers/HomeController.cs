using FirstCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsContext db;

        public HomeController(NewsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Contact(ContactUs model)
        {
            if (!ModelState.IsValid)
                return View(model);

            db.Contacts.Add(model);
            db.SaveChanges();

            return Redirect(nameof(Index));
        }

        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Messages()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult News(int id)
        {
            var category = db.Categories.Find(id);
            if (category == null)
                return NotFound();

            var news = db.News.Where(c => c.categoryId == id).OrderByDescending(n=>n.Date).ToList();
            ViewBag.category = category.Name;
            ViewBag.description = category.Description;

            return View(news);
        }

        public IActionResult New(int id)
        {
            var n= db.News.Find(id);
            if (n == null)
                return NotFound();

            ViewBag.NewTitle = n.Title;
            return View(n);
        }

        [Authorize(Roles ="SuperAdmin")]
        public IActionResult DeleteNew(int id)
        {
            var New = db.News.Find(id);
            if (New == null)
                return NotFound();

            db.News.Remove(New);
            db.SaveChanges();

            return RedirectToAction("News", new { id = New.categoryId });
        }

        public IActionResult Teammembers()
        {
            return View(db.Teammembers.ToList());
        }
    }//end class
}//end main
