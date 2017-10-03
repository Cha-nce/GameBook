using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private readonly LessonContext _context;

    public FriendsController(LessonContext context)
    {
        _context = context;
        _context.SaveChanges();
    }

        // POST api/values
        [HttpPost]
        public void Post(int fromUserId, int toUserId)
        {
            User user1 = _context.Users.FirstOrDefault(u => u.Id == fromUserId);
            User user2 = _context.Users.FirstOrDefault(u => u.Id == toUserId);
            if (user1.Friends == null)
            {
                user1.Friends = new List<User>();
            }
            if (user2.Friends == null)
            {
                user2.Friends = new List<User>();
            }
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            _context.SaveChanges();
        }



    }
}