﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Shop
{
    [Migration(291220230006)]
    public class InitialSP_291220230006 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[AddNewOrder]
                      GO

                      CREATE PROCEDURE [Order].[AddNewOrder] 
                            @OrderId int,
                         	@UserId int,
                         	@OrderDate datetime,
                         	@ProductsCount int,
                         	@PackerId int,
                         	@OrderState int,
                         	@TotalPrice decimal

                      AS   
                         INSERT INTO [dbo].[Order] (OrderId, UserID, OrderDate, ProductCounts, PackerId, OrderState, TotalPrice)
                         VALUES (@OrderId, @UserID, @OrderDate, @ProductsCount, @PackerId, @OrderState, @TotalPrice)
                      GO  
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Order].[AddNewOrder] 
                      """;
            Execute.Sql(sql);
        }

    }
}
