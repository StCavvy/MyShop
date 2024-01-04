using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230005)]

    public class InitialFK_291220230005 : Migration
    {
        public override void Up()
        {
            string sql = """
                         IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_User_to_Order]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_User_To_Order] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
                         END

 
                         """;
            Execute.Sql(sql);
        }

        public override void Down()
        {
            string sql = """
                         IF EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_User_To_Order]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_User_To_Order]
                         END
                         """;
            Execute.Sql(sql);
        }
    }
}
