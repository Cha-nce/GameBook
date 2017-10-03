using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class ClansController : Controller
    {
        private readonly LessonContext _context;
        
        public ClansController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // GET api/values
        [HttpGet]
        public List<Clan> Get()
        {
            return _context.Clans.Include("clanleader").Include("clanmembers").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Clan Get(int id)
        {
            return _context.Clans.Include("clanleader").Include("clanmembers").FirstOrDefault(u => u.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post(string cname, int fromUserId)
        {
            Clan c = new Clan{
                clanname = cname,
                clanleader = _context.Users.FirstOrDefault(u => u.Id == fromUserId),
                clanmembers = new List<User>(),
            };
            c.clanmembers.Add(_context.Users.FirstOrDefault(u => u.Id == fromUserId));
            _context.Clans.Add(c);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Clan value)
        {
            _context.SaveChanges();
            _context.Clans.Remove(_context.Clans.FirstOrDefault(clan => clan.Id == id));
            _context.Clans.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (Clan clan in _context.Clans)
            {
                if (clan.Id == id)
                {
                    if(clan.Id == id)
                    {
                        _context.Clans.Remove(clan);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}