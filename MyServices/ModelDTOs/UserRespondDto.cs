using MyServices.Enums;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static UserRespondDto Map(DataRow row)
        {
            UserRespondDto user = new UserRespondDto
            {
                Id =            (int) row["Id"],
                Email =      (string) row["Email"],
                UserName =   (string) row["UserName"],
                Name =       (string) (row.IsNull("Name") ? "" : row["Name"]),
                Birthday = (DateTime) (row.IsNull("Birthday") ? (DateTime)default : row["Birthday"]),
                Gender = (GenderEnum) row["GenderId"]
            };

            return user;
        }
    }
}