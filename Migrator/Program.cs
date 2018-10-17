namespace Migrator
{
    using System;
    using System.IO;

    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var sqlConnectionString = configuration.GetConnectionString("DefaultSqlConnectionString");
            var entityFrameworkConnectionString = configuration.GetConnectionString("EntityFrameworkConnectionString");
            var mongoDbconnectionString = configuration.GetConnectionString("MongoDbConnectionString");


            Console.WriteLine("1. Migrate sql db dictionaries to orm db");

            var key = Console.ReadLine();

            switch (key)
            {
                case "1": CommandProvider.MigrateSqlToOrm(sqlConnectionString, entityFrameworkConnectionString);
                    break;
                default: Console.WriteLine("Команда отсутствует");
                    break;
            }

            Console.ReadLine();
        }
    }
}
