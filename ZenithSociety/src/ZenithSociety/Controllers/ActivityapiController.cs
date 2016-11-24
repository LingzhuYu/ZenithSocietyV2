using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using ZenithSociety.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety.Controllers
{
    [Route("api/[controller]")]
    public class ActivityapiController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public ActivityapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/activityapi
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activities.ToList();
        }

        // GET api/activityapi/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(a => a.ActivityId == id);
        }

        // POST api/activityapi
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
        }

        // PUT api/activityapi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Activity activity)
        {
            _context.Activities.Update(activity);
            _context.SaveChanges();
        }

        // DELETE api/activityapi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(a => a.ActivityId == id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
        }
    }
}
