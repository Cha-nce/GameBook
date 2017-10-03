using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class DirectMessagesController : Controller
    {
        private readonly LessonContext _context;

        public DirectMessagesController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // GET api/values
        [HttpGet]
        public List<DirectMessage> Get()
        {
            return _context.DirectMessages.Include(r => r.user1).Include(r => r.user2).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public DirectMessage Get(int id)
        {
            foreach (DirectMessage dm in _context.DirectMessages)
            {
                if (dm.Id == id)
                {
                    return dm;
                }
            }
            return null;
        }

       // POST api/values
        [HttpPost]
        public void Post(int fromUserId, int toUserId, string message)
        {
            _context.DirectMessages.Add(new DirectMessage{
                user1 = _context.Users.FirstOrDefault(u => u.Id == fromUserId),
                user2 = _context.Users.FirstOrDefault(u => u.Id == toUserId),
                RequestType = "DirectMessage",
                Message = message
            });
            // _context.FriendsRequests.Add(d);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]DirectMessage value)
        {
            _context.SaveChanges();
            _context.DirectMessages.Remove(_context.DirectMessages.FirstOrDefault(fr => fr.Id == id));
            _context.DirectMessages.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (DirectMessage dm in _context.DirectMessages)
            {
                if (dm.Id == id)
                {
                    if (dm.Id == id)
                    {
                        _context.DirectMessages.Remove(dm);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}