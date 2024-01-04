using Dapper;
using Microsoft.Data.SqlClient;
using Shop.ClassesLibrary;
using System.Data;
using System.Security.Cryptography;


namespace Shop.Main.DataManagers
{
    internal class OrderManager 
    {
        public static void AddOrder(int ID, int UserId, DateTime OrderDate, int ProductsCount, List<int> ProductsId, int PackerId, OrderStates OrderState, string str)
        {
            using (var connection = new SqlConnection(str))
            {
                decimal TotalPrice = 0;

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("OrderId", ID);
                parameters.Add("UserID", UserId);
                parameters.Add("OrderDate", OrderDate);
                parameters.Add("ProductsCount", ProductsCount);
                parameters.Add("PackerId", PackerId);
                parameters.Add("OrderState", OrderState);
                for (int i = 0; i < ProductsCount; i++)
                {
                    var values = new { ProductId = ProductsId[i] };
                    var Product = connection.QuerySingleOrDefault<Product>("Product.GetProductById", values, commandType: CommandType.StoredProcedure);
                    TotalPrice += Product.Price;
                }
                parameters.Add("TotalPrice", TotalPrice);
                connection.Query("Order.AddNewOrder", parameters, commandType: CommandType.StoredProcedure);

                for (int i = 0; i < ProductsCount; i++)
                {
                    var storedProcedureName = "Order.AddOrderPosition";
                    var values = new { OrderId = ID, ProductId = ProductsId[i] };
                    connection.Query(storedProcedureName, values, commandType: CommandType.StoredProcedure);
                }
            }
        }
        public static Order GetOrderById(int ID, string str)
        {
            using (var connection = new SqlConnection(str))
            {
                var i = 0;
                var values = new { OrderId = ID };
                var order = connection.QuerySingleOrDefault<Order>("Order.GetOrderInfoById", values, commandType: CommandType.StoredProcedure);
                var storedProcedureName = "Order.GetOrderPosition";
                var result = connection.QueryMultiple(storedProcedureName, values, commandType: CommandType.StoredProcedure);
                var OrderPositions = result.Read();
                foreach (var position in OrderPositions)
                {
                    order.ProductsId.Add (position.ProductId);
                }
                return order;
            }
        }
    }
}
