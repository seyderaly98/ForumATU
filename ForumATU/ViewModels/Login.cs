using System.ComponentModel.DataAnnotations;

namespace ForumATU.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string EmailAndUserName { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string Password { get; set; }

    }
}