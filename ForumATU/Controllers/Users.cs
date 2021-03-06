using Microsoft.AspNetCore.Mvc;

namespace ForumATU.Controllers
{
    public class Users : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}