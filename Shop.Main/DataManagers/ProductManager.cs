using Dapper;
using Microsoft.Data.SqlClient;
using Shop.ClassesLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Main.DataManagers
{
    internal class ProductManager
    {
        public static async void AddProduct(int ID, string Name, string? Description, decimal Price, ProductType Category, string str)
        {
            await Task.Run(() =>
            {
                using (var connection = new SqlConnection(str))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("ProductId", ID);
                    parameters.Add("Name", Name);
                    parameters.Add("Description", Description);
                    parameters.Add("Price", Price);
                    parameters.Add("Category", Category);

                    connection.Query("Order.AddProduct", parameters, commandType: CommandType.StoredProcedure);
                }
            });
        }
    }
}
