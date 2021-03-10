using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ForumATU.Models;
using ForumATU.Models.Data;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager { get; set; }
        ForumContext _db { get; set; }
        
        public UsersController(UserManager<User> userManager, ForumContext db)
        {
            _userManager = userManager;
            _db = db;
        }


        // GET
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var user =await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return View(new UserData(user));
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> UserEdit(UserData model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }
    }
}