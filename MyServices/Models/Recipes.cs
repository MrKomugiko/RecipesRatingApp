using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyServices.Models
{
    public class Recipes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public string UrlImage { get; set; } = "https://trimurl.co/JYKFkn";
        [Required]
        public int UserId { get; set; }

        //--------------------------------------------
        [ForeignKey("UserId")]
        public User User{ get; set; }
    }
}