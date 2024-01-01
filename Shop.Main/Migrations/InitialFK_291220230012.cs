﻿using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Main.Migrations
{
    [Migration(291220230012)]
    public class InitialFK_291220230012 : Migration
    {
        public override void Up()
        {
            string sql = """
                         IF NOT EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Packer_To_Order]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[Order] ADD CONSTRAINT [FK_Packer_To_Order] FOREIGN KEY ([PackerId]) REFERENCES [User] ([Id])
                         END
                         """;
            Execute.Sql(sql);
        }
        public override void Down()
        {
            string sql = """
                         IF EXISTS (SELECT * FROM sys.objects o WHERE o.object_id = object_id(N'[FK_Packer_To_Order]') AND OBJECTPROPERTY(o.object_id, N'IsForeignKey') = 1)
                         BEGIN
                             ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Packer_To_Order]
                         END
                         """;
            Execute.Sql(sql);
        }

    }
}