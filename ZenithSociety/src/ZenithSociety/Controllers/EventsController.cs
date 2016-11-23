using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Models;
using ZenithSociety.Data;

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
       /* public ActionResult Index()
        {
            var events = _context.Events.Include(m => m.Activity).Include(n => n.ApplicationUser);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var eventList = _context.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            Event @event = _context.Events.Find(id);
            @event.ActivityId = currentEvent.ActivityId;

            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
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
        public ActionResult Create([Bind(Include = "EventId,StartDate,EndDate,Id,CreationDate,IsActive,ActivityId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.CreationDate = DateTime.Now;
                @event.Id = User.Identity.GetUserId();
                _context.Events.Add(@event);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _context.Events.Find(id);
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
        public ActionResult Edit([Bind(Include = "EventId,StartDate,EndDate,Id,CreationDate,IsActive,ActivityId")] Event @event)
        {
            @event.CreationDate = Convert.ToDateTime(String.Format("{0:MM'/'dd'/'yyyy hh:mm tt}", db.Events.Find(@event.EventId).CreationDate));
            @event.Id = _context.Events.Find(@event.EventId).Id;

            if (ModelState.IsValid)
            {
                //db.Entry(@event).State = EntityState.Modified;
                _context.Events.AddOrUpdate(@event);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            ViewBag.Id = new SelectList(_context.Users, "Id", "UserName", @event.Id);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Gets Activity Id from db and places it in @event
            var eventList = _context.Events.Include(m => m.Activity);
            var currentEvent = eventList.Where(m => m.EventId == id).First();

            Event @event = _context.Events.Find(id);
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
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _context.Events.Find(id);
            _context.Events.Remove(@event);
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
