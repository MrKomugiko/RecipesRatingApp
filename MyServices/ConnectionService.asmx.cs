using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class ConnectionService : WebService
    {

        private string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        [WebMethod]
        public bool Login(LoginRequestDto data)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string command = "Select COUNT([Id]) from [Users]" +
                             $" Where [UserName] = '{data.UserName}'" +
                             $" AND [Password] = '{data.Password}';";

            SqlCommand cmd = new SqlCommand(command, conn);

            int matches = Int32.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            return matches != 0 ? true:false;
        }

        [WebMethod]
        public bool Register(RegisterRequestDto data)
        {
            string sql = $"INSERT INTO [Users]([Email], [UserName], [Birthday], [Name], [Password], [SecurityQuestion], [Answer], [GenderId])" +
                             $"Values('{data.Email}', '{data.UserName}', {default(DateTime)}, '{(String.IsNullOrEmpty(data.Name)?null:data.Name)}', '{data.Password}', '{data.SecurityQuestion}', '{data.Answer}', '{data.GenderId}');";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                
                try
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return true;
        }
    }
}
