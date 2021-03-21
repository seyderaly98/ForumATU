using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumATU.ViewModels
{
    public class TopicViewModel
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public int TopicEventId { get; set; }
        public string TopicEventDescription { get; set; }
        
        /// <summary>
        /// Заголовок темы
        /// </summary>
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [MinLength(3,ErrorMessage = "Заголовок должен содержать не менее 3 символов.")]
        public string TopicTitle { get; set; }

        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [MinLength(3,ErrorMessage = "Описание темы должен содержать не менее 10 символов.")]
        public string Description { get; set; }
        /// <summary>
        /// Метки 
        /// </summary>
        /// Несколько меток разделены запятыми.
        public string Marks { get; set; }

        /// <summary>
        /// Отслеживать эту тему...
        /// </summary>
        public bool TrackTopic { get; set; }
        /// <summary>
        /// Получать уведомления на электронную почту
        /// </summary>
        public bool Notifications { get; set; }
        
        public IFormFile File { get; set; }

        public TopicViewModel()
        {
            
        }

    }
}