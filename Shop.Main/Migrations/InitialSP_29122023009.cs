using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Main.Migrations
{
    [Migration(29122023009)]
    public class InitialSP_29122023009 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[DeleteOrderById] 
                      GO

                      CREATE PROCEDURE [Order].[DeleteOrderById]
                            @OrderId int
                      AS   
                         DELETE 
                         FROM [dbo].[Order]
                         WHERE OrderId = @OrderId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[DeleteOrderById]
                      """;
        }

    }
}
