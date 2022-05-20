using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyServices.ModelDTOs
{
    public class RecipeRequstDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime? Created { get; set; }
        public string UrlImage { get; set; }
        public float AvgRating { get; set; }
        public int TotalVotes { get; set; }
    }
}