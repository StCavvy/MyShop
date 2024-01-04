using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FluentMigrator;

namespace Shop
{
    [Migration(281220230001)]
    public class InitialTables_281220230001 : Migration
    {

        public override void Up()
        {
            if (Schema.Table("Order").Exists())
            {

            }
            else
            {
                Create.Table("Order")
                    .WithColumn("OrderId").AsInt32().NotNullable().PrimaryKey()
                    .WithColumn("UserId").AsInt32().NotNullable()
                    .WithColumn("OrderDate").AsDateTime()
                    .WithColumn("ProductCounts").AsInt32().NotNullable()
                    .WithColumn("PackerId").AsInt32().NotNullable()
                    .WithColumn("OrderState").AsInt32().NotNullable()
                    .WithColumn("TotalPrice").AsDecimal().NotNullable();
            }

        }
        public override void Down()
        {
            if (Schema.Table("Order").Exists())
            {
                Delete.Table("Order");
            }
        }
    }
}
