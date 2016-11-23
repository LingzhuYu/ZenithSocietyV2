using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Models;
using Microsoft.EntityFrameworkCore;
using ZenithSociety.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public IActionResult Index()
        {
            return View(_context.Activities.ToList());
        }

        // GET: Activities/Details/5
       /* public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _context.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(Include = "ActivityId,ActivityDescription,CreationDate")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.CreationDate = DateTime.Now;
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: Activities/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _context.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(Include = "ActivityId,ActivityDescription,CreationDate")] Activity activity)
        {
            activity.CreationDate = Convert.ToDateTime(String.Format("{0:MM'/'dd'/'yyyy hh:mm tt}", db.Events.Find(activity.ActivityId).CreationDate));

            if (ModelState.IsValid)
            {
                _context.Entry(activity).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = _context.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Activity activity = _context.Activities.Find(id);
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
