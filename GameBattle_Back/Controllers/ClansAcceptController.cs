using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameBattle.Controllers
{
    [Route("api/[controller]")]
    public class ClansAcceptController : Controller
    {
        private readonly LessonContext _context;

    public ClansAcceptController(LessonContext context)
    {
        _context = context;
        _context.SaveChanges();
    }

        // POST api/values
        [HttpPost]
        public void Post(int toUserId, int toClanId)
        {
            User user2 = _context.Users.FirstOrDefault(u => u.Id == toUserId);
            Clan clan = _context.Clans.Include("clanmembers").FirstOrDefault(u => u.Id == toClanId);

            
            clan.clanmembers.Add(user2);
            _context.SaveChanges();
        }



    }
}