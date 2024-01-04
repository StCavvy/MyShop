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
                DROP PROCEDURE IF EXISTS [Users].[AddUser]
                GO

                CREATE PROCEDURE [Users].[AddUser]
                    @UserId int,
                	@FirstName nvarchar(250),
                	@LastName nvarchar(250),
                	@UserType int,
                	@RegistrationDate DateTime
                AS 
                INSERT INTO [dbo].[User] (UserId, FirstName, LastName, UserType, RegistrationDate)
                VALUES (@UserId, @FirstName, @LastName, @UserType, @RegistrationDate)
                GO
                """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [Users].[AddUser]
                GO
                """;
            Execute.Sql(sql);
        }
    }
}
