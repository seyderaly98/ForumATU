using System.Threading.Tasks;
using ForumATU.Models;
using ForumATU.Models.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Controllers
{
    public class ValidationController : Controller
    {
        private ForumContext _db;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public ValidationController(ForumContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<bool> CheckEmail(string email)
        {
            return !await _db.Users.AnyAsync(u => u.Email == email);
        }
        
        public async Task<bool> CheckUserName(string userName)
        {
            return !await _db.Users.AnyAsync(u => u.UserName == userName.ToLower());
        }
    }
}