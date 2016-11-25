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

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mondayOfTheWeek = getMondayOfTheWeek();

            var events = _context.Events.Include(m => m.Activity).Include(n => n.ApplicationUser)
                           .Where(p => p.IsActive == true);

            ViewBag.DateFormat = "{0:dddd MMMM dd, yyyy}";
            ViewBag.TimeFormat = "{0:h:mm tt}";

            return View(events.ToList().Where(d => (d.StartDate >= mondayOfTheWeek) && (d.EndDate <= mondayOfTheWeek.AddDays(7)))
                        .OrderBy(d => d.StartDate));
        }

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

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

        //Gets the monday of this week using DateTime.Now as basis
        private DateTime getMondayOfTheWeek()
        {
            var currentDay = DateTime.Now;
            var currentHour = currentDay.Hour;
            var currentMinute = currentDay.Minute;
            var currentSecond = currentDay.Second;

            var delta = DayOfWeek.Monday - currentDay.DayOfWeek;

            DateTime mondayOfTheWeek = currentDay.AddDays(delta).AddHours(-1 * currentHour).AddMinutes(-1 * currentMinute).AddSeconds(-1 * currentSecond);
            return mondayOfTheWeek;
        }
    }
}
