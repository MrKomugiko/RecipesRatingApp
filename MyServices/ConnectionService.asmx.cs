﻿using MyServices.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyServices
{
    /// <summary>
    /// Opis podsumowujący dla ConnectionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Aby zezwalać na wywoływanie tej usługi sieci Web ze skryptu za pomocą kodu ASP.NET AJAX, usuń znaczniki komentarza z następującego wiersza. 
    // [System.Web.Script.Services.ScriptService]
    public class ConnectionService : System.Web.Services.WebService
    {

        private string ConnectionString = "Data Source=ASUS-MRKOMUGIKO;Initial Catalog=WebRecipesDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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
            DateTime nulldate = DateTime.Parse("1-01-0001");
            string bdayvalue = (data.Birthday == nulldate ? "null" : data.Birthday.ToString());
            string sql = $"INSERT INTO \"Users\"(Email, UserName, Birthday, Name, Password, SecurityQuestion, Answer, GenderId)" +
                             $"Values('{data.Email}', '{data.UserName}', {bdayvalue}, '{(data.Name==""?null:data.Name)}', '{data.Password}', '{data.SecurityQuestion}', '{data.Answer}', '{data.GenderId}');";

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
