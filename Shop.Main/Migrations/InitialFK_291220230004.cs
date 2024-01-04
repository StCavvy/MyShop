using FluentMigrator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230004)]
    public class InitialFK_291220230004 : Migration
    {


        public override void Up()
        {
            string sql = """
                         IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Order_To_OrderPositions]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[OrderPositions] ADD CONSTRAINT [FK_Order_To_OrderPositions] FOREIGN KEY ([OrderId]) REFERENCES [Order] ([OrderId])
                         END
                         """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = """
                         IF EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Order_To_OrderPositions]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[OrderPositions] DROP CONSTRAINT [FK_Order_To_OrderPositions]
                         END
                         """;
            Execute.Sql(sql);
        }

    }

}
