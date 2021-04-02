using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForumATU.Models;
using ForumATU.Models.Data;
using ForumATU.Services;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ForumATU.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private UserManager<User> UserManager { get; }
        private ForumContext _db { get; }

        public HomeController(UserManager<User> userManager, ForumContext db)
        {
            UserManager = userManager;
            _db = db;
        }


       
        public async Task<IActionResult> Index()
        {
            var titleEvents = _db.TitleEvents.ToList();
            ViewBag.User = await UserManager.Users.FirstOrDefaultAsync(u => u.Id == UserManager.GetUserId(User));
            ViewBag.Statistics = await _db.Statistics.Include(u => u.User).FirstOrDefaultAsync();
            return View(titleEvents);
        }


        public async Task<IActionResult> TitleEvent(int titleEventId)
        {
            var titleEvent = await _db.TitleEvents.Include(i=>i.TopicEvents).ThenInclude(t => t.Author).FirstOrDefaultAsync(i => i.Id == titleEventId);
            if (titleEvent != null)
            {
                return View(titleEvent);
            }
            return NotFound();
        }

        public async Task<IActionResult> Topic(int topicEventId)
        {
            var topicEvent = await _db.TopicEvents.FirstOrDefaultAsync(t=>t.Id == topicEventId);
            if (topicEvent != null)
            {
                return View(topicEvent);
            }
            return NotFound();
        }
        

        public async Task<IActionResult> CreateThread(int topicEventId)
        {
            var topicEvent = await _db.TopicEvents.FirstOrDefaultAsync(t => t.Id == topicEventId);
            if (topicEvent == null) return NotFound();
            var topicViewModel = new TopicViewModel{TopicEventId = topicEvent.Id, TopicEventDescription = topicEvent.Description};
            return View(topicViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateThread(TopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _db.TopicEvents.AnyAsync(t => t.Id == model.TopicEventId))
                {
                    string authorId = UserManager.GetUserId(User);
                    Topic topic = new Topic(model,authorId);
                    await _db.Topics.AddAsync(topic);
                    var statistics = await _db.Statistics.FirstOrDefaultAsync();
                    statistics.Topic += 1;
                    var topicEvent = await _db.TopicEvents.FirstOrDefaultAsync(t => t.Id == model.TopicEventId);
                    topicEvent.MessageNumber += 1;
                    topicEvent.TopicNumber += 1;
                    topicEvent.ChangeDate = DateTime.Now;
                    topicEvent.AuthorChangeId = UserManager.GetUserId(User);
                    var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == UserManager.GetUserId(User));
                    user.MessageNumber += 1;
                    _db.Users.Update(user);
                    _db.TopicEvents.Update(topicEvent);
                    _db.Statistics.Update(statistics);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Topic", model.TopicEventId);
                }
                else
                    ModelState.AddModelError("","Ошибка!! Попробуйте перезагрузить страницу");
            }
            return View(model);
        }

        public async Task<IActionResult> TopicDetails(int topicId)
        {
            Topic topic = await _db.Topics.FirstOrDefaultAsync(t => t.Id == topicId);
            if (topic == null) return NotFound();
            return View(topic);
        }

        /// <summary>
        /// Комментировать тему
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Comment(int topicId,string comment)
        {
            try
            {
                if (topicId == 0 || string.IsNullOrEmpty(comment) || !await _db.Topics.AnyAsync(t => t.Id == topicId)) return Json(false);

                var author = await _db.Users.FirstOrDefaultAsync(u => u.Id == UserManager.GetUserId(User));
                var topicComment = new TopicMessage(comment, author.Id,topicId);
                await _db.TopicMessages.AddAsync(topicComment);
                await _db.SaveChangesAsync();
                topicComment.Author = author;
                return PartialView("Partial/PartialTopicComment",topicComment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}