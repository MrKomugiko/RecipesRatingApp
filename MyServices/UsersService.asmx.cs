using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyServices
{
    /// <summary>
    /// Opis podsumowujący dla UsersService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class UsersService : System.Web.Services.WebService
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        [WebMethod]
        public List<UserRespondDto> GetAllUsers()
        {
            List<UserRespondDto> Users = new List<UserRespondDto>();

            string sql = "SELECT [Id],[Email],[UserName],[Name],[Birthday],[GenderId] FROM[Users]";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                foreach (DataRow row in dt.Rows)
                {
                    Users.Add(UserRespondDto.Map(row));
                }

                reader.Close();
            }
            
            return Users;
        }
    }
}
