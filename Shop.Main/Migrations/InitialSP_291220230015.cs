using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230015)]
    public class InitialSP_291220230015 : Migration
    {
        public override void Up()
        {
            var sql = """
                      DROP PROCEDURE IF EXISTS [Product].[UpdateProductById] 
                      GO

                      CREATE PROCEDURE [Product].[UpdateProductById]
                            @ProductId int,
                            @Name nvarchar(250),
                         	@Description nvarchar(4000),
                         	@Price decimal,
                         	@ProductType int

                      AS   
                         UPDATE [Product].[UpdateProductById]
                         SET  Id = @ProductId,
                              Name = @Name,
                              Description = @Description,
                              Price = @Price,
                              ProductType = @ProductType
                         WHERE Id = @ProductId
                      GO
                      """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            var sql = "DROP PROCEDURE IF EXISTS [Product].[UpdateProductById] ";
            Execute.Sql(sql);
        }
    }
}
