using FluentMigrator.Expressions;
using Microsoft.Data.SqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class UserManager
    {
        public static void AddUser(int UserID, string FirstName, string LastName, UserType UserType, DateTime RegistrationDate, string str)
        {
            using (var connection = new SqlConnection(str))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserId", UserID);
                parameters.Add("FirstName", FirstName);
                parameters.Add("LastName", LastName);
                parameters.Add("UserType", UserType);
                parameters.Add("RegistrationDate", RegistrationDate);

                connection.Query("Users.AddUser", parameters, commandType: CommandType.StoredProcedure);
            }
        }
        
    }
}
