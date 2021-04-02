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
    [Authorize]
    public class UsersController : Controller
    {
        #region поле
        UserManager<User> _userManager { get; set; }
        ForumContext _db { get; set; }
        
        #endregion
        
        #region конструкторы
        
        public UsersController(UserManager<User> userManager, ForumContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        
        #endregion
        
        #region Actions

        // GET
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);                                                             // Получаем Id авторизованного пользователя 
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);                                    // Получаем экземпляр авторизованного пользовтеля
            return View(new UserData(user));                                                                       // Вернем виде UserData
        }
        
        
        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> UserEdit(UserData model)
        {
                if (ModelState.IsValid)                                                                                 // Валидация request (Проверка, являются ли какие-либо значения состояния модели в этом modelstatedictionary недопустимыми или не проверенными.)
                {       
                    var userId = _userManager.GetUserId(User);                                                     // Получаем Id авторизованного пользователя 
                    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);                            // Получаем экземпляр авторизованного пользовтеля
                    if (user != null)                                                                                   // user не должно быть null (страховка)                            
                    {         
                        user.Edit(model);                                                                               // Редактируем даные пользователя. В данном случае используем метод Edit класса User
                        await _userManager.UpdateAsync(user);                                                           // Обновляем Db
                        return RedirectToAction("Index");                                                               // Переадресуем на Get Index
                    }    
                    return NotFound();                                                                                  // Если Пользовтель не найден (такого не должно быть) возвращаем статус кода 404
                }    
                return View(model);                                                                                     // Если Request (model) не проходит валидацию, тогда возвращаем ошибку валидации
            }

        
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(string status)
        {
            try
            {
                if (string.IsNullOrEmpty(status)) return Json(false);                                               // Проверка: Если status пустой, вернуть false. Пользователь получает сообщение (Статус не сохранен).. Также на уровне view имеется валидация 
                var userId = _userManager.GetUserId(User);                                                         // Получить Id авторизованного  пользователя   
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);                                // Получить экземпляр (данные) авторизованного пользователя 
                user.Status = status;                                                                                   // Присвоить новый статус пользователю  
                await _userManager.UpdateAsync(user);                                                                   // Обновить статус
                return Json(true);                                                                                  // Вернуть true. Статус пользователя обновляется на новой                                                                                 
            }
            catch (Exception ex)
            {
                return Json(ex.Message);                                                                                // В случае ошибки вернем message ошибки. 99.9% это не пригодится если не трогать корень 
            }                                                                                                           // Пользователю откроется 'alert' чтобы смог обновить страницу и сразу попробовать еще раз изменить статус 
        }
        
        #endregion

    }
}