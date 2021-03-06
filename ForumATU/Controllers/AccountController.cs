using System;
using System.Linq;
using System.Threading.Tasks;
using ForumATU.Models;
using ForumATU.Models.Data;
using ForumATU.Services;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace ForumATU.Controllers
{
    public class AccountController : Controller
    {
        #region поле 
        UserManager<User> _userManager { get; set; }
        RoleManager<IdentityRole> _roleManager { get; set; }
        SignInManager<User> _signInManager { get; set; }
        ForumContext _db { get; set; }
        IHostEnvironment _environment { get; set; }
        
        #endregion

        #region конструктор
        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, ForumContext db, IHostEnvironment environment)
         {
             _userManager = userManager;
             _roleManager = roleManager;
             _signInManager = signInManager;
             _db = db;
             _environment = environment;
         }
       
        #endregion
        
        #region actions
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
                    ModelState.AddModelError("","Неверный пароль или логин пользователя");
            }
            return View(model);
        }
        
        public IActionResult Regist()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Regist(Register model)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User(model);
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, Convert.ToString(RoleInitializer.Roles.Student));
                    await _db.SaveChangesAsync();
                    await _signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(String.Empty, error.Description);
            }
            return View(model);
        }
        
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
        
        #endregion

    }
}