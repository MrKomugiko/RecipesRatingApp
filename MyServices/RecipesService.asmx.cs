using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
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

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Recipes.Add(RecipeRespondDto.Map(reader));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return Recipes;
        }
    }
}
