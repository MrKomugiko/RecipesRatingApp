using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyServices.Models
{
    public class Ratings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RecipeId { get; set; }

        //--------------------------------------------
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("UserId")]
        public Recipes Recipe { get; set; }
    }
}