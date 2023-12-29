using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Main.Migrations
{
    [Migration(29122023008)]
    public class InitialSP_29122023008 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[UpdateOrderById] 
                      GO

                      CREATE PROCEDURE [Order].[UpdateOrderById]
                            @OrderId int,
                            @ProductsCount int,
                         	@PackerId int,
                         	@OrderState int,
                         	@TotalPrice decimal

                      AS   
                         UPDATE [dbo].[Order] 
                         SET  ProductCounts = @ProductsCount,
                              PackerId = @PackerId,
                              OrderState = @OrderState,
                              TotalPrice = @TotalPrice
                         WHERE OrderId = @OrderId
                      GO
                      """;
            Execute.Sql(sql);

        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[UpdateOrderById]
                      """;
            Execute.Sql(sql);
        }
    }
}
