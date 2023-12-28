using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FluentMigrator;

namespace Shop
{
    [Migration(202328120001)]
    internal class InitialDatabase_202328120001 : Migration
    {
        public override void Down()
        {
           
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
