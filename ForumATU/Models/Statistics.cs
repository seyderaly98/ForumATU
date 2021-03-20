using System.Linq;

namespace ForumATU.Models.Data
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
        public string User { get; set; }

        public void Update(ForumContext _db)
        {
            Topic = _db.Topics.Count();
            Topic += _db.TopicEvents.Count();
            Topic += _db.ItemEvents.Count();

            Message = _db.Messages.Count();
            _db.Statistics.Update(this);
        }
    }
}