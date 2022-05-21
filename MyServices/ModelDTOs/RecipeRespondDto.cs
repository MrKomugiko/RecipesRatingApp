using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyServices.ModelDTOs
{
    public class RecipeRespondDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime? Created { get; set; }
        public string UrlImage { get; set; }
        public float AvgRating { get; set; }
        public int TotalVotes { get; set; }

        public static RecipeRespondDto Map(DataRow row)
        {
            RecipeRespondDto recipe = new RecipeRespondDto
            {
                Id =             (int) row["Id"],           
                Title =       (string) row["Title"],         
                Description = (string) row["Description"],     
                UserId =         (int) row["UserId"],           
                Created =   (DateTime) row["Created"],        
                UrlImage =    (string) row["UrlImage"],         
                AvgRating =    (float) (row.IsNull("AvgRating")?0:(decimal)row["AvgRating"]),           
                TotalVotes =     (int) row["TotalVotes"],            
            };

            return recipe;
        }
    }
}