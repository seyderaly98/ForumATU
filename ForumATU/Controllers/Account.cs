using ForumATU.Models;
using ForumATU.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ForumATU.Controllers
{
    public class Account : Controller
    {
        public UserManager<User> _userManager { get; set; }
        public RoleManager<IdentityRole> _roleManager { get; set; }
        public SignInManager<User> _signInManager { get; set; }
        public ForumContext _db { get; set; }
        public IHostEnvironment _environment { get; set; }
        
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }
        
        
        
    }
}