using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System.Reflection;



namespace Shop
{
    internal class Program
    {
        private static IConfigurationRoot config;
        static void Main()
        {
            using (var connection = new SqlConnection(config.GetConnectionString("MyShop")))
            {

            }
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
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
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
