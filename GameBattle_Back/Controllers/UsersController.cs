using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly LessonContext _context;
        
        public UsersController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
            if (_context.Users.Count() == 0)
            {
                User user1 = new User();
                user1.Id = 1;
                user1.Username = "b00oo00m3r4ng";
                user1.Firstname = "Shaneal";
                user1.Lastname = "Prasad";
                user1.Email = "shanealp@uci.edu";
                user1.Password = "shaneal";
                user1.ProfilePic = "https://static-resource.np.community.playstation.net/avatar/3RD/30004.png";
                user1.Friends = new List<User>();

                User user2 = new User();
                user2.Id = 2;
                user2.Username = "CHAKA_CHAKA";
                user2.Firstname = "Chance";
                user2.Lastname = "Hernandez";
                user2.Email = "chanceh@uci.edu";
                user2.Password = "chance";
                user2.ProfilePic = "http://www.psnleaderboard.com/images/avatars/E0004.png";
                user2.Friends = new List<User>();       

                User user3 = new User();
                user3.Id = 3;
                user3.Username = "2PumpChump";
                user3.Firstname = "Spiritual";
                user3.Lastname = "Leader";
                user3.Email = "scrummaster@harvard.edu";
                user3.Password = "karim";
                user2.ProfilePic = "http://www.psnleaderboard.com/images/avatars/E0004.png";
                user3.Friends = new List<User>();

                _context.Users.Add(user1);
                _context.Users.Add(user2);
                _context.Users.Add(user3);

                _context.SaveChanges();
            }
        }
        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.Include("Friends.Friends").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            foreach (User user in _context.Users.Include("Friends.Friends").ToList())
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (User user in _context.Users)
            {
                if (user.Id == id)
                {
                    if(user.Id == id)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
