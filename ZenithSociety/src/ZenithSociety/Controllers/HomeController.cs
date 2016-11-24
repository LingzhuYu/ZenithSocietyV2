using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithSociety.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Show()
        {
            var events = _context.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            events.OrderByDescending(d => d.StartDate);

            ViewBag.DateFormat = "{0:dddd MMMM dd, yyyy}";
            ViewBag.TimeFormat = "{0:h:mm tt}";

            return View(events.ToList());
        }
    }
}
