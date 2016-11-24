using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Models;
using ZenithSociety.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Events
        public ActionResult Index()
        {
            var events = _context.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var eventList = _context.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            Event @event = _context.Events.Where(e => e.EventId == id).First();
            @event.ActivityId = currentEvent.ActivityId;

            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(_context.Activities, "ActivityId", "ActivityDescription");
            ViewBag.Id = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.CreationDate = DateTime.Now;
                // @event.Id = User.Identity.GetUserId();
                @event.Id = "34234";
                _context.Events.Add(@event);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(_context.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = await _context.Events.SingleOrDefaultAsync(e => e.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewBag.ActivityId = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(_context.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Event @event)
        {
            //@event.CreationDate = Convert.ToDateTime(String.Format("{0:MM'/'dd'/'yyyy hh:mm tt}", _context.Events.Find(@event.EventId).CreationDate));
            @event.CreationDate = DateTime.Now;
            //@event.Id = _context.Events.Where(e => e.EventId == id).First().Id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Events.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(_context.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Gets Activity Id from db and places it in @event
            var eventList = _context.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            var @event = await _context.Events.SingleOrDefaultAsync(e => e.EventId == id);
            @event.ActivityId = currentEvent.ActivityId;

            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(e => e.EventId == id);

            _context.Events.Remove(@event);
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
