using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;
using Dapper;
using Shop.ClassesLibrary;
using System.Data;
using Z.Dapper.Plus;
using Shop.Main.DataManagers;
using System;



namespace Shop
{
    public class Program
    {
        public static IConfigurationRoot config;
        static void Main()
        {

            Initconfig();

            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                RunMigration(scope.ServiceProvider);
            }

            Console.Clear();

            /*
            List<User> users = new List<User>();
            users.Add(new User() { UserId = 1, FirstName = "Frank", LastName = "Collins", UserType = UserType.Customer, RegistrationDate = DateTime.Now });
            users.Add(new User() { UserId = 2, FirstName = "Derek", LastName = "Dixon", UserType = UserType.Worker, RegistrationDate = DateTime.Now });
            users.Add(new User() { UserId = 3, FirstName = "Alice", LastName = "Nakovsky", UserType = UserType.Administrator, RegistrationDate = DateTime.Now });
            users.Add(new User() { UserId = 4, FirstName = "Andrew", LastName = "Beryls", UserType = UserType.Customer, RegistrationDate = DateTime.Now }); 

            using (var connection = new SqlConnection(config.GetConnectionString("MyShop")))
            {
                connection.BulkInsert(users);
            } 

            List<Product> products = new List<Product>();
            products.Add(new Product() { ProductId = 1, Name = "Drill", Price = 2799.5m, Category = ProductType.ElectricalInstrument, Description = " Electrical drill" });
            products.Add(new Product() { ProductId = 2, Name = "Concrete", Price = 199.0m, Category = ProductType.Material, Description = "Concrete bag" });
            products.Add(new Product() { ProductId = 3, Name = "Screwdriver", Price = 299.0m, Category = ProductType.HandInstrument, Description = "Screwdriver" });
            products.Add(new Product() { ProductId = 4, Name = "Fork lifter", Price = 22799.0m, Category = ProductType.Machine, Description = "Fork lifter" });
            products.Add(new Product() { ProductId = 5, Name = "Helmet", Price = 799.5m, Category = ProductType.Equipment, Description = "Helmet" });
            products.Add(new Product() { ProductId = 6, Name = "Jackhammer", Price = 3799.5m, Category = ProductType.ElectricalInstrument, Description = "JackHammer" });

            using (var connection = new SqlConnection(config.GetConnectionString("MyShop")))
            {
                connection.BulkInsert(products);
            }
            
            List<int> OrderPositions = new List<int>();
            OrderPositions.Add(1);
            OrderPositions.Add(6);
            OrderPositions.Add(4);
            OrderManager.AddOrder(1, 4, DateTime.Now, 3, OrderPositions, 2, OrderStates.Pending, config.GetConnectionString("MyShop")); 
            */
            Order order = OrderManager.GetOrderById(1, config.GetConnectionString("MyShop"));

            string products_id = null;
            for (int i = 0; i < order.ProductCounts; i++)
            {
                products_id += order.ProductsId[i] + " ";
            }
            
            Console.WriteLine($"Order № {order.OrderId},\nUserId - {order.UserId},\nPackerId - {order.PackerId},\nOrder date - {order.OrderDate},\n" +
                $"ProductsId - {products_id},\nOrder state - {order.OrderState.ToString()},\nTotal price - {order.TotalPrice} ");

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Same, but joined with table User, column FirstName");
            Console.WriteLine("-------------------------------------------");

            Order order1 = new Order();
            using (var connection = new SqlConnection(config.GetConnectionString("MyShop")))
            {
                var sql = """
                Select FirstName as UserName, OrderId, [Order].[UserId], OrderDate, ProductCounts, PackerId, OrderState, TotalPrice
                FROM [dbo].[User]
                JOIN [dbo].[Order] ON [User].[UserId] = [Order].[UserId];
                """;
                order1 = connection.QuerySingle<Order>(sql);
            }

            Console.WriteLine($"Order № {order1.OrderId},\nUserId - {order1.UserId},\nUserName - {order1.UserName},\nPackerId - {order1.PackerId},\nOrder date - {order1.OrderDate},\n" +
                $"ProductsId - {products_id},\nOrder state - {order.OrderState.ToString()},\nTotal price - {order.TotalPrice} ");






        }
        public static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2012()
                       .WithGlobalConnectionString(config.GetConnectionString("MyShop"))
                       .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.MigrateUp();
        }
        private static void RunMigration(IServiceProvider serviceProvider)
        {
            var migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
            migrationService.ListMigrations();
            migrationService.MigrateUp();
        }

        public static void Initconfig()
        {
            var builder = new ConfigurationBuilder();
            builder
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            config = builder.Build();
        }

    }
}
