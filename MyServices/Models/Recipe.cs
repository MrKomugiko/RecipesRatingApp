using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyServices.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string UrlImage { get; set; } = "https://trimurl.co/JYKFkn";
        [Required]
        public int UserId { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;

        //--------------------------------------------
        [ForeignKey("UserId")]
        public User User{ get; set; }

        public static Recipe Map(SqlDataReader reader)
        {
            Recipe recipe = new Recipe
            {
                Id = (int)reader.GetValue(reader.GetOrdinal("Id")),
                Title = (string)reader.GetValue(reader.GetOrdinal("Title")),
                Description = (string)reader.GetValue(reader.GetOrdinal("Description")),
                UserId = (int)reader.GetValue(reader.GetOrdinal("UserId")),
                Created = (DateTime)reader.GetValue(reader.GetOrdinal("Created")),
                UrlImage = (string)reader.GetValue(reader.GetOrdinal("UrlImage"))
            };

            return recipe;
        }
    }
}