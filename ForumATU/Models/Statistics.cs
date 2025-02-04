﻿using System.Linq;
using ForumATU.Models.Data;

namespace ForumATU.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        /// <summary>
        /// Темы
        /// </summary>
        public int Topic { get; set; }
        /// <summary>
        /// Сообщения
        /// </summary>
        public int Message { get; set; }
        /// <summary>
        /// Пользователи
        /// </summary>
        public int Users { get; set; }
        /// <summary>
        /// ID нового пользователя
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// Новы пользователь
        /// </summary>
        public virtual User User { get; set; }

        public async void Update(ForumContext _db)
        {
            Topic = _db.Topics.Count() + _db.TopicEvents.Count() + _db.TitleEvents.Count();
            Message = _db.TopicMessages.Count();
            Users = _db.Users.Count();
            // _db.Statistics.Update(this);
            await _db.SaveChangesAsync();
        }

        public void UpdateTopic()
        {
            this.Topic += 1;
        }
    }
}