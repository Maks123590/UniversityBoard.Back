namespace UniversityBoard.Migrator
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


            Console.WriteLine("0. Migrate sql db structure");
            Console.WriteLine("1. Migrate sql db Data");
            Console.WriteLine("2. Migrate sql db dictionaries to ORM db");
            Console.WriteLine("3. Migrate sql db dictionaries to NOSQL db");

            while (true)
            {
                var key = Console.ReadLine();

                var onBreak = false;

                switch (key)
                {
                    case "0":
                        CommandProvider.MigrateSqlDbStructure(sqlConnectionString);
                        break;
                    case "1":
                        CommandProvider.MigrateSqlDbData(sqlConnectionString);
                        break;
                    case "2":
                        CommandProvider.MigrateSqlToOrm(sqlConnectionString, entityFrameworkConnectionString);
                        break;
                    case "3":
                        CommandProvider.MigrateSqlToNoSql(sqlConnectionString, mongoDbconnectionString);
                        break;
                    default: onBreak = true;
                        break;
                }

                if (onBreak)
                {
                    break;
                }

                Console.WriteLine("Complete!");
            }
        }
    }
}
