using System;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ForumATU.Models
{
    public enum Faculty
    {
        /// <summary>
        /// Факультет Пищевых Производств
        /// </summary>
        FacultyOfFoodProduction,
        /// <summary>
        /// Факультет Легкой Промышленности и Дизайна
        /// </summary>
        FacultyOfLightIndustryAndDesign,
        /// <summary>
        /// Факультет Инжиниринга и Информационных Технологий
        /// </summary>
        FacultyOfEngineeringAndInformationTechnology,
        /// <summary>
        /// Факультет экономики и бизнеса
        /// </summary>
        FacultyOfEconomicsAndBusiness,
        /// <summary>
        /// Факультет дистанционного обучения
        /// </summary>
        FacultyOfDistanceLearning
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
        public string Status { get; set; }
        public Gender Gender { get; set; }
        public string AvatarPath { get; set; }

        
        #region Конструктор
        public User()
        {
            AvatarPath = "/images/img/avatar_non.png";
            Status = "Online";
            Gender = Gender.None;
        }
        public User(Register model)
        {
            Email = model.Email;
            UserName = model.UserName.ToLower();
        }
        
        #endregion
    }
}