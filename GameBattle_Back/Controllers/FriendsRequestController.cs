using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class FriendsRequestController : Controller
    {
        private readonly LessonContext _context;

        public FriendsRequestController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // GET api/values
        [HttpGet]
        public List<FriendRequest> Get()
        {
            return _context.FriendsRequests.Include(r => r.user1).Include(r => r.user2).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public FriendRequest Get(int id)
        {
            foreach (FriendRequest fr in _context.FriendsRequests)
            {
                if (fr.Id == id)
                {
                    return fr;
                }
            }
            return null;
        }



        // POST api/values
        [HttpPost]
        public void Post(int fromUserId, int toUserId)
        {
            FriendRequest f = new FriendRequest{
                user1 = _context.Users.FirstOrDefault(u => u.Id == fromUserId),
                user2 = _context.Users.FirstOrDefault(u => u.Id == toUserId),
                RequestType = "FriendRequest"
            };

            _context.FriendsRequests.Add(f);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]FriendRequest value)
        {
            _context.SaveChanges();
            _context.FriendsRequests.Remove(_context.FriendsRequests.FirstOrDefault(fr => fr.Id == id));
            _context.FriendsRequests.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (FriendRequest fb in _context.FriendsRequests)
            {
                if (fb.Id == id)
                {
                    if (fb.Id == id)
                    {
                        _context.FriendsRequests.Remove(fb);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}