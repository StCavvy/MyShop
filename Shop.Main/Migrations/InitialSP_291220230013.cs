using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230013)]
    public class InitialSP_291220230013 : Migration
    {
        public override void Up()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [Product].[AddProduct]
                GO

                CREATE PROCEDURE [Product].[AddProduct]
                    @ProductId int,
                	@Name nvarchar(250),
                	@Description nvarchar(4000),
                	@Price decimal,
                	@Category int 
                AS 
                INSERT INTO [dbo].[Product] (ProductId, Name, Description, Price, Category)
                VALUES (@ProductId, @Name, @Description, @Price, @Category)
                GO
                """;
            Execute.Sql(sql);
        }

        public override void Down()
        {
            var sql = """
                DROP PROCEDURE IF EXISTS [Product].[AddProduct]
                DROP SCHEMA IF EXISTS [Product]
                GO
                """;
        }
    }
}
