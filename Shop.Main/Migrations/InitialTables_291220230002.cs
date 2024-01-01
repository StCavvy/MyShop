using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230002)]
    public class InitialTables_291220230002 : Migration
    {
        public override void Up()
        {
            if (Schema.Table("OrderPositions").Exists())
            {

            }
            else
            {
                Create.Table("OrderPositions")
                     .WithColumn("OrderId").AsInt32().NotNullable()
                     .WithColumn("ProductId").AsInt32().NotNullable();
            }
        }
        public override void Down()
        {
            if (Schema.Table("OrderPositions").Exists())
            {
                Delete.Table("OrderPositions");
            }
        }
    }
}
