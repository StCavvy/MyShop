using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    [Migration(291220230003)]
    public class InitialTables_291220230003 : Migration
    {
        public override void Up()
        {
            if (Schema.Table("User").Exists())
            {

            }
            else
            {
                Create.Table("User")
                        .WithColumn("UserId").AsInt32().NotNullable().PrimaryKey()
                        .WithColumn("FirstName").AsString().NotNullable()
                        .WithColumn("LastName").AsString().NotNullable()
                        .WithColumn("UserType").AsInt32().NotNullable()
                        .WithColumn("RegistrationDate").AsDateTime().NotNullable();
            }
            }
        public override void Down()
        {
            if (Schema.Table("User").Exists())
            {
                Delete.Table("User");
            }
        }
    }
}
