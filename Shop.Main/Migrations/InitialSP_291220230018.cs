using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230018)]
    public class InitialSP_291220230018 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Users].[GetUserById]
                      GO

                      CREATE PROCEDURE [Users].[GetUserById]
                        @UserId int
                      As
                        SELECT* 
                        FROM [dbo].[User] 
                        WHERE UserId = @UserId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Users].[GetUserById]
                      """;
            Execute.Sql(sql);
        }
    }
}
