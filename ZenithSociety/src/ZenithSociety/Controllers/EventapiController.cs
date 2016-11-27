using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithSociety.Data;
using ZenithSociety.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithSociety.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class EventapiController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public EventapiController(ApplicationDbContext context)
        {
           _context = context;
        }

            // GET: api/eventapi
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _context.Events.ToList();
        }

        // GET api/eventapi/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(e => e.EventId == id);
        }

        // POST api/eventapi
        [HttpPost]
        public void Post([FromBody]Event e)
        {
            _context.Events.Add(e);
            _context.SaveChanges();
        }

        // PUT api/eventapi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event e)
        {
            _context.Events.Update(e);
            _context.SaveChanges();
        }

        // DELETE api/eventapi/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var e = _context.Events.FirstOrDefault(m => m.EventId == id);
            if (e != null)
            {
                _context.Events.Remove(e);
                _context.SaveChanges();
            }
        }
    }
}
