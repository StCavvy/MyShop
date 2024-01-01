using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230019)]
    public class InitialSP_291220230019 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [User].[UpdateUserById] 
                      GO

                      CREATE PROCEDURE [User].[UpdateUserById]
                            @Id int,
                            @FirstName nvarchar(250),
                         	@LastName nvarchar(250),
                         	@UserType int
                      AS   
                         UPDATE [User].[UpdateUserById]
                         SET
                              FirstName = @FirstName,
                              LastName = @LastName,
                              UserType = @UserType
                         WHERE Id = @Id
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [User].[UpdateUserById] 
                      """;
            Execute.Sql(sql);
        }
    }
}
