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
        public IActionResult Index()
        {
            var itemEvents = _db.ItemEvents.Include(i=>i.Topics).ThenInclude(t =>t.Author).ToList();
            return View(itemEvents);
        }

        
    }
}