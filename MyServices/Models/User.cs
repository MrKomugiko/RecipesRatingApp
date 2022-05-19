using MyServices.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyServices.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        [Required] [MaxLength(50)] 
        public string Email { get; set; }
        [Required] [MaxLength(50)] 
        public string UserName { get; set; }
        [MaxLength(50)] 
        public string Name { get; set; }
        public DateTime? Birthday { get; set; } 
        [Required] [MaxLength(150)] 
        string SecurityQuestion { get; set; }
        [Required] 
        string Answer { get; set; }
        [Required] 
        string Password { get; set; }
        public int GenderId { get; set; } // GendersEnum
    }
}