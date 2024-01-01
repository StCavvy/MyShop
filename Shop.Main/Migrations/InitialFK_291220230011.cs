using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230011)]
    public class InitialFK_291220230011 : Migration
    {
        public override void Up()
        {
            string sql = """
                         IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Product_To_OrderPositions]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[OrderPositions] ADD CONSTRAINT [FK_Product_To_OrderPositions] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
                         END
                         """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = """
                         IF EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Product_To_OrderPositions]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[OrderPositions] DROP CONSTRAINT [FK_Product_To_OrderPositions]
                         END
                         """;
            Execute.Sql(sql);
        }
    }
}
