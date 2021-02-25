using System;
using System.ComponentModel.DataAnnotations;
using ForumATU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumATU.ViewModels
{

    public class Register
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [EmailAddress(ErrorMessage = "Пожалуйста, введите действительный адрес электронной почты.")]
        [Remote("CheckEmail","Validation",ErrorMessage = "Данный электронный адрес используется другим аккаунтом.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [DataType(DataType.Password)]
        [MinLength(3,ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Пароли не совпадают.")]
        [MinLength(3,ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string ConfirmPassword { get; set; }
    }

    public class DetailedRegister : Register
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        public DateTime DateBirth { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        
        /// <summary>
        /// Факультет
        /// </summary>
        public Faculty Faculty { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        /// <summary>
        /// Специальность 
        /// </summary>
        public string Specialty { get; set; }
        
        [Required(ErrorMessage = "Это поле необходимо заполнить.")]
        /// <summary>
        /// Курс
        /// </summary>
        public int Course { get; set; }
        
        public Gender Gender { get; set; }
    }
}