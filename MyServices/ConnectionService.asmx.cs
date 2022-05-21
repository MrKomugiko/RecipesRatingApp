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
    [WebService(Namespace = "http://myservices.somee.com/ConnectionService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class ConnectionService : WebService
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        [WebMethod]
        public UserRespondDto Login(LoginRequestDto data)
        {
            string command = "Select TOP 1 * from [Users]" +
                             $" Where [UserName] = '{data.UserName}'" +
                             $" AND [Password] = '{data.Password}';";

            UserRespondDto user = null;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(command, conn);

                try
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    user = (UserRespondDto.Map(dt.Rows[0]));
                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            return user;
        }

        [WebMethod]
        public RegisterResultDto Register(RegisterRequestDto data)
        {
            RegisterResultDto result = new RegisterResultDto();
            string sql = $"INSERT INTO [Users]([Email], [UserName], [Birthday], [Name], [Password], [SecurityQuestion], [Answer], [GenderId])" +
                             $"Values('{data.Email}', '{data.UserName}', Cast({"1-1-1"} as DATETIME), '{(String.IsNullOrEmpty(data.Name) ? null : data.Name)}', '{data.Password}', '{data.SecurityQuestion}', '{data.Answer}', '{data.GenderId}');";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();
                    var rowsaffected = cmd.ExecuteNonQuery();
                    result.Success = rowsaffected == 1;
                    result.Message = "Succes, account created";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }
    }
}
