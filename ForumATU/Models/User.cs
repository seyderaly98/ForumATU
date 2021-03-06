using System;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ForumATU.Models
{
    public enum Faculty
    {
        
    }

    public enum Gender 
    {
        None,
        Man,
        Woman
    }
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateBirth { get; set; }
        
        /// <summary>
        /// Факультет
        /// </summary>
        public Faculty? Faculty { get; set; }
        
        /// <summary>
        /// Специальность 
        /// </summary>
        public string Specialty { get; set; }
        
        /// <summary>
        /// Курс
        /// </summary>
        public int Course { get; set; }

        public Gender Gender { get; set; } = Gender.None;

        
        #region Конструктор
        
        public string AvatarPath { get; set; }

        public User()
        {
            
        }
        public User(Register model)
        {
            Email = model.Email;
            UserName = model.UserName.ToLower();
            
        }
        
        #endregion
    }
}