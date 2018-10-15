namespace Migrator
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var sqlConnection = "server=localhost;user=root;database=batunin_402_user;SslMode=none";
            var ormConnection = "server=localhost;user=root;database=batunin_402_user_orm;SslMode=none";


            Console.WriteLine("1. Migrate sql db dictionaries to orm db");
            var key = Console.ReadLine();

            if (key == "1")
            {
                using (var migrator = new SqlToOrmMigrator(sqlConnection, ormConnection))
                {
                    migrator.MigrateSqlDbToOrmDb();

                    Console.ReadLine();
                }
            }
        }
    }
}
