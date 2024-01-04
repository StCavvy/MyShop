using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230016)]
    public class InitialSP_291220230016 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Product].[DeleteProductById] 
                      GO

                      CREATE PROCEDURE [Product].[DeleteProductById] 
                            @ProductId int
                      AS   
                         DELETE 
                         FROM [dbo].[Product]
                         WHERE ProductId = @ProductId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Product].[DeleteProductById]  
                      """;
            Execute.Sql(sql);
        }
    }
}
