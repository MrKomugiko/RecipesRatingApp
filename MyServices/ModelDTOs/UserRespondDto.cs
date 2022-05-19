using MyServices.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyServices.ModelDTOs
{
    public class UserRespondDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; } 
        public GenderEnum Gender { get; set; }

        public static UserRespondDto Map(SqlDataReader reader)
        {
            UserRespondDto user = new UserRespondDto
            {
                Id = (int)reader.GetValue(reader.GetOrdinal("Id")),
                Email = (string)reader.GetValue(reader.GetOrdinal("Email")),
                UserName = (string)reader.GetValue(reader.GetOrdinal("UserName")),
                Name = reader.IsDBNull(reader.GetOrdinal("Name")) ? null : (string)reader.GetValue(reader.GetOrdinal("Name")),
                Birthday = reader.IsDBNull(reader.GetOrdinal("Birthday")) ? default : (DateTime)reader.GetValue(reader.GetOrdinal("Birthday")),
                Gender = (GenderEnum)reader.GetValue(reader.GetOrdinal("GenderId"))
            };

            return user;
        }
    }
}