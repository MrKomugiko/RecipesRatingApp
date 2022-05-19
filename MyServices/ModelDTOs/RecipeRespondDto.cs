using System;
using System.Collections.Generic;
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

        public static RecipeRespondDto Map(SqlDataReader reader)
        {
            RecipeRespondDto recipe = new RecipeRespondDto
            {
                Id = (int)reader.GetValue(reader.GetOrdinal("Id")),
                Title = (string)reader.GetValue(reader.GetOrdinal("Title")),
                Description = (string)reader.GetValue(reader.GetOrdinal("Description")),
                UserId = (int)reader.GetValue(reader.GetOrdinal("UserId")),
                Created = (DateTime)reader.GetValue(reader.GetOrdinal("Created")),
                UrlImage = (string)reader.GetValue(reader.GetOrdinal("UrlImage")),
                AvgRating = reader.IsDBNull(reader.GetOrdinal("AvgRating")) ? 0 : (float)(decimal)reader.GetValue(reader.GetOrdinal("AvgRating")),
                TotalVotes = (int)reader.GetValue(reader.GetOrdinal("TotalVotes"))
            };

            return recipe;
        }
    }
}