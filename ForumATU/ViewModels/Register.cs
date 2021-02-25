using System;
using ForumATU.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ForumATU.ViewModels
{

    public class Register
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

        public Gender Gender { get; set; }
    }
}