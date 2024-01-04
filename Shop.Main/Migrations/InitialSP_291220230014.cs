using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230014)]
    public class InitialSP_291220230014 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Product].[GetProductById]
                      GO

                      CREATE PROCEDURE [Product].[GetProductById]
                        @ProductId int
                      As
                        SELECT* 
                        FROM [dbo].[Product] 
                        WHERE ProductId = @ProductId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Product].[GetProductById]
                      GO
                      """;
            Execute.Sql(sql);
        }
    }
}
