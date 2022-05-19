using MyServices.Enums;
using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class UserRespondDtosService : WebService
    {

        private string ConnectionString = "Data Source=ASUS-MRKOMUGIKO;Initial Catalog=WebRecipesDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        [WebMethod]
        public List<UserRespondDto> GetAllUsers()
        {
            List<UserRespondDto> Users = new List<UserRespondDto>();

            string sql = "SELECT [Id],[Email],[UserRespondDtoName],[Name],[Birthday],[GenderId] FROM[UserRespondDtos]";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Users.Add(UserRespondDto.Map(reader));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return Users;
        }
    }
}
