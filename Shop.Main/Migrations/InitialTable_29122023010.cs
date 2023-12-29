using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Main.Migrations
{
    [Migration(29122023010)]
    public class InitialTable_29122023010 : Migration
    {
        public override void Up()
        {
            if (Schema.Table("Product").Exists())
            {

            }
            else
            {
                Create.Table("Product")
                    .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
                    .WithColumn("Name").AsString().NotNullable()
                    .WithColumn("Description").AsString()
                    .WithColumn("Price").AsDecimal().NotNullable()
                    .WithColumn("Category").AsInt32().NotNullable();
            }
        }
        public override void Down()
        {
            if (Schema.Table("Product").Exists())
            {
                Delete.Table("Product");
            }
        }
    }
}
