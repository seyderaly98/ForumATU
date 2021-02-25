using System.Linq;
using System.Threading.Tasks;
using ForumATU.Models;
using ForumATU.Models.Data;
using ForumATU.ViewModels;
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
        
        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                User userAuthorizing = _db.Users.FirstOrDefault(u => u.Email == model.EmailAndUserName || u.UserName == model.EmailAndUserName);
                if (userAuthorizing != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        userAuthorizing,
                        model.Password,
                        false,
                        false
                    );
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("","Неверный пароль или логин пользователя ");
            }
            return View(model);
        }
        
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }
        
        
    }
}