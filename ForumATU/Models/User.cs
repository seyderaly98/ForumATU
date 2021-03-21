using System;
using System.ComponentModel.DataAnnotations.Schema;
using ForumATU.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ForumATU.Models
{
    #region enum
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
    #endregion
    public sealed class User : IdentityUser
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
        public string Group{ get; set; }
        public string AboutMe { get;  set; }

        public DateTime CrateDate { get;} = DateTime.Now;
        public DateTime ChangeDate { get; private set; } = DateTime.Now;
        public double Rating { get;  }
        public int Like { get;  }
        public int MessageNumber { get; set; }
        public int NewMessageNumber { get; set; }

        [NotMapped]
        private Random Random = new Random();
        

        #region Конструктор
        public User()
        {
            AvatarPath = $"/images/avatar/{Random.Next(1,10)}.png";
            Status = "Online";
            Gender = Gender.None;
        }
        public User(Register model)
        {
            Email = model.Email;
            UserName = model.UserName.ToLower();
            AvatarPath = $"/images/avatar/{Random.Next(1,10)}.png";
            Status = "Online";
            Gender = Gender.None;
        }
        
        #endregion

        /// <summary>
        /// Данный метод обновляет поля текущего экземпляра на UserData (model)
        /// </summary>
        /// <param name="model">Request typeof(UserData)</param>
        public void Edit(UserData model)
        {
            Name = model.Name;
            Surname = model.Surname;
            DateBirth = model.DateBirth;
            Faculty = model.Faculty;
            Specialty = model.Specialty;
            Course = model.Course;
            Gender = model.Gender;
            Group = model.Group;
            AboutMe = model.AboutMe;
            ChangeDate = DateTime.Now;
        }
        
    }
}