using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using ForumATU.Models;
using Microsoft.AspNetCore.Http;

namespace ForumATU.ViewModels
{
    /// <summary>
    /// Данный класс предназначен для заполнения данных о пользователе 
    /// </summary>
    public class UserData 
    {
        #region поле

        public string UserName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Surname { get; set; }
        public DateTime DateBirth { get; set; }
        
        /// <summary>
        /// Факультет
        /// </summary>
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public Faculty? Faculty { get; set; }
        public string FacultyName => GetFacultyName();

        /// <summary>
        /// Специальность 
        /// </summary>
        // [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Specialty { get; set; }
        
        /// <summary>
        /// Курс
        /// </summary>
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [Range(1,5,ErrorMessage = "1 - 5")]
        public int Course { get; set; }
        public string Status { get; set; }
        
        public Gender Gender { get; set; } = Gender.None;

        public string AvatarPath { get; set; }

        public IFormFile File { get; set; }
        
        
        #endregion

        #region Конструктор

        public UserData(){}
        public UserData(User user)
        {
            UserName = user.UserName;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            DateBirth = user.DateBirth;
            Faculty = user.Faculty;
            Specialty = user.Specialty;
            Course = user.Course;
            Status = user.Status;
            Gender = user.Gender;
            AvatarPath = user.AvatarPath;
        }
        

        #endregion

        
        #region private методы
        private string GetFacultyName()
        {
            if (Faculty == null) return "Факультет не указан"; /// не должно пригодится 
            switch (Faculty)
            {
                case Models.Faculty.FacultyOfFoodProduction: return "Факультет Пищевых Производств";
                case Models.Faculty.FacultyOfLightIndustryAndDesign:
                    return "Факультет Легкой Промышленности и Дизайна";
                case Models.Faculty.FacultyOfEngineeringAndInformationTechnology:
                    return "Факультет Инжиниринга и Информационных Технологий";
                case Models.Faculty.FacultyOfEconomicsAndBusiness: return "Факультет экономики и бизнеса";
                case Models.Faculty.FacultyOfDistanceLearning: return "Факультет дистанционного обучения";
            }
            return "Факультет не указан"; /// не должно пригодится 
        }
        
        #endregion
        
    }
}