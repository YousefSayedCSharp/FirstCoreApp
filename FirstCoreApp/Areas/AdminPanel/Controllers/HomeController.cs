using FirstCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Areas.AdminPanel.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private readonly NewsContext db;

        public HomeController(NewsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            int cate= db.Categories.Count();
            int news= db.News.Count();
            int msg= db.Contacts.Count();
            int team= db.Teammembers.Count();

            ViewData["CateCount"] = cate;
            ViewData["NewsCount"] = news;
            ViewData["MsgCount"] = msg;
            ViewData["TeamCount"] = team;

            return View();
        }
    }
}
