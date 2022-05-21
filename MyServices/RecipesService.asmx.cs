using MyServices.ModelDTOs;
using MyServices.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace MyServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class RecipesService : WebService
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        [WebMethod]
        public List<RecipeRespondDto> GetAllRecipes()
        {
            List<RecipeRespondDto> Recipes = new List<RecipeRespondDto>();

            string sql = "SELECT [Recipes].[Id], [Recipes].[Title], [Recipes].[Description], [Recipes].[UserId], [Recipes].[Created],[Recipes].[UrlImage]," +
                        "Cast(AVG(Cast([Ratings].[Rate] as DECIMAL))as DECIMAL(10,2)) as [AvgRating], COUNT([Ratings].[Id]) as [TotalVotes]" +
                        "FROM [Recipes]" +
                        "LEFT JOIN [Ratings] as [Ratings] on [Ratings].[RecipeId] = [Recipes].[Id]" +
                        "GROUP BY [Recipes].[Id], [Recipes].[Title], [Recipes].[Description], [Recipes].[UserId],[Recipes].[Created],[Recipes].[UrlImage];";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach(DataRow row in dt.Rows)
                    Recipes.Add(RecipeRespondDto.Map(row));
                }

            return Recipes;
        }

        [WebMethod]
        public Recipe GetRecipeById(int _id)
        {
            string sql = $"SELECT TOP 1 * FROM [Recipes] WHERE [Id]={_id};";
            Recipe result = new Recipe();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (!reader.HasRows) return null;

                DataTable dt = new DataTable();
                dt.Load(reader);
                DataRow row = dt.Rows[0];
 
                result = Recipe.Map(row);

                return result;               
            }
        }

        [WebMethod]
        public Recipe Add(RecipeAddRequestDto _recipe)
        {
            string sql = $"INSERT INTO [Recipes] ( [Title], [Description], [UserId], [UrlImage] ) " +
                         $"VALUES ( '{_recipe.Title}', '{_recipe.Description}', '{_recipe.UserId}', '{_recipe.UrlImage}' );";

            Recipe result = new Recipe();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);

                if (!reader.HasRows) return null;

                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach(DataRow row in dt.Rows)
                {
                    result = Recipe.Map(row);
                }
               
                return result;
            }
        }
    }
}
