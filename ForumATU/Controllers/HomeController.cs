using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumATU.Models;
using ForumATU.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> UserManager { get; }
        private ForumContext _db { get; }

        public HomeController(UserManager<User> userManager, ForumContext db)
        {
            UserManager = userManager;
            _db = db;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var titleEvents = _db.TitleEvents.Include(i=>i.TopicEvents).ThenInclude(t =>t.Author).ToList();
            ViewBag.User = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == UserManager.GetUserId(User));
            ViewBag.Statistics = await _db.Statistics.Include(u => u.User).FirstOrDefaultAsync();
            return View(titleEvents);
        }

        [Authorize]
        public async Task<IActionResult> TitleEvent(int titleEventId)
        {
            var titleEvent = await _db.TitleEvents.Include(i=>i.TopicEvents).ThenInclude(t => t.Author).FirstOrDefaultAsync(i => i.Id == titleEventId);
            if (titleEvent != null)
            {
                return View(titleEvent);
            }
            return NotFound();
        }
        
    }
}