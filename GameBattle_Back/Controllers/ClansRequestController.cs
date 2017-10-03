using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class ClansRequestController : Controller
    {
        private readonly LessonContext _context;

        public ClansRequestController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // GET api/values
        [HttpGet]
        public List<ClanRequest> Get()
        {
            return _context.ClansRequests.Include(r => r.user1).Include(r => r.user2).Include(r => r.clan).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ClanRequest Get(int id)
        {
            foreach (ClanRequest cr in _context.ClansRequests)
            {
                if (cr.Id == id)
                {
                    return cr;
                }
            }
            return null;
        }



        // POST api/values
        [HttpPost]
        public void Post(int fromUserId, int toUserId, int toClanId, string message)
        {
            ClanRequest c = new ClanRequest{
                user1 = _context.Users.FirstOrDefault(u => u.Id == fromUserId),
                user2 = _context.Users.FirstOrDefault(u => u.Id == toUserId),
                clan = _context.Clans.FirstOrDefault(u => u.Id == toClanId),
                message = message,
                RequestType = "ClanRequest"
            };

            _context.ClansRequests.Add(c);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ClanRequest value)
        {
            _context.SaveChanges();
            _context.ClansRequests.Remove(_context.ClansRequests.FirstOrDefault(cr => cr.Id == id));
            _context.ClansRequests.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (ClanRequest cr in _context.ClansRequests)
            {
                if (cr.Id == id)
                {
                    if (cr.Id == id)
                    {
                        _context.ClansRequests.Remove(cr);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}