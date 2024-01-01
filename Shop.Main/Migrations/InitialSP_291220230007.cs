using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230007)]
    public class InitialSP_291220230007 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[GetOrderInfoById]
                      GO

                      CREATE PROCEDURE [Order].[GetOrderInfoById]
                        @OrderId int
                      As
                        SELECT* 
                        FROM [dbo].[Order] 
                        WHERE OrderId = @OrderId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[GetOrderInfoById]
                      """;
            Execute.Sql(sql);
        }   
    }
}
