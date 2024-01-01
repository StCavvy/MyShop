using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230017
        )]
    public class InitialSP_291220230017 : Migration
    {
        public override void Up()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [User].[AddUser]
                GO

                CREATE PROCEDURE [User].[AddUser]
                    @Id int,
                	@FirstName nvarchar(250),
                	@LastName nvarchar(250),
                	@UserType int,
                	@RegistrationDate DateTime
                AS 
                INSERT INTO [User].[AddUser] (Id, FirstName, LastName, UserType, RegistrationDate)
                VALUES (@Id, @FirstName, @LastName, @UserType, @RegistrationDate)
                GO
                """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [User].[AddUser]
                GO
                """;
            Execute.Sql(sql);
        }
    }
}
