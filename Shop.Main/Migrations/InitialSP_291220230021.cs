using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230021)]
    public class InitialSP_291220230021 : Migration
    {
        public override void Up()
        {
            var sql = """
                                DROP PROCEDURE IF EXISTS [Order].[AddOrderPosition]
                GO

                DROP PROCEDURE IF EXISTS [Order].[DeleteOrderPosition]
                GO

                DROP PROCEDURE IF EXISTS [Order].[GetOrderPosition]
                GO

                CREATE PROCEDURE [Order].[AddOrderPosition]
                     @OrderId int,
                	 @ProductId int
                AS
                INSERT INTO [dbo].[OrderPositions] (OrderId, ProductId)
                VALUES (@OrderID, @ProductId)
                GO

                CREATE PROCEDURE [Order].[GetOrderPosition]
                @OrderId int
                AS
                SELECT * 
                FROM [dbo].[OrderPositions]
                WHERE OrderId = @OrderID
                GO

                CREATE PROCEDURE [Order].[DeleteOrderPosition]
                @OrderId int
                AS 
                DELETE 
                FROM [dbo].[OrderPositions]
                WHERE OrderId = @OrderID
                GO
                """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [Order].[AddOrderPosition]
                GO

                DROP PROCEDURE IF EXISTS [Order].[DeleteOrderPosition]
                GO

                DROP PROCEDURE IF EXISTS [Order].[GetOrderPosition]
                """;
            Execute.Sql(sql);
        }
    }
}
