using System;
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
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return View(new UserData(user));
        }
                  
        [Authorize]
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> UserEdit(UserData model)
        {
            try
            {
                /// Валидация request
                if (ModelState.IsValid)                                                                  
                {       
                    // Получаем Id авторизованного пользователя 
                    var userId = _userManager.GetUserId(User);       
                    // Получаем экземпляр самого пользовтеля
                    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);                 
                    if (user != null) // user не должно быть null (страховка)                            
                    {         
                        // Редактируем даные пользователя. В данном случае используем метод Edit класса User
                        user.Edit(model);    
                        /// Обновляем Db
                        await _userManager.UpdateAsync(user);
                        /// Переадресуем на Get Index
                        return RedirectToAction("Index");                                                       
                    }    
                    /// Если Пользовтель не найден (такого не должно быть) возвращаем статус кода 404
                    return NotFound();                                                                   
                }    
                /// Если Request (model) не проходит валидацию, тогда возвращаем ошибку валидации
                return View(model);                                                                      
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string status)
        {
            try
            {
                if (!string.IsNullOrEmpty(status))
                {
                    var userId = _userManager.GetUserId(User);
                    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
                    if (user != null)
                    {
                        user.Status = status;
                        await _userManager.UpdateAsync(user);
                        return Json(true);
                    }
                }
                return Json(false);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}