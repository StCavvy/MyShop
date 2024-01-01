using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230020)]
    public class InitialSP_291220230020 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [User].[DeleteByUserId]
                      GO

                      CREATE PROCEDURE [User].[DeleteByUserId]
                            @UserId int
                      AS   
                         DELETE 
                         FROM [dbo].[User]
                         WHERE Id = @UserId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [User].[DeleteByUserId]
                      """;
            Execute.Sql(sql);
        }
    }
}
