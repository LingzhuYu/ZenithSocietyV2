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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == id);
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
        public IActionResult Create (Activity activity)
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == id);
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
        public async Task<IActionResult> Edit(int? id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return NotFound();
            }

            //activity.CreationDate = Convert.ToDateTime(String.Format("{0:MM'/'dd'/'yyyy hh:mm tt}", _context.Events.Where(a => a.EventId == id).First().CreationDate));
            activity.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Activities.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var activity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.SingleOrDefaultAsync(a => a.ActivityId == id);

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
