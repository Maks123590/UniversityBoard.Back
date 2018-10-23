namespace UniversityBoard.Migrator
{
    using MySql.Data.MySqlClient;

    using SimpleMigrations;
    using SimpleMigrations.DatabaseProvider;

    public static class CommandProvider
    {
        public static void MigrateSqlToNoSql(string sqlConnectionString, string mongoDbConnectionString)
        {
            using (var migrator = new SqlToNoSqlMigrator(sqlConnectionString, mongoDbConnectionString))
            {
                migrator.MigrateSqlDbToNoSqlDb();
            }
        }

        public static void MigrateSqlToOrm(string sqlConnectionString, string entityFrameworkConnectionString)
        {
            using (var migrator = new SqlToOrmMigrator(sqlConnectionString, entityFrameworkConnectionString))
            {
                migrator.MigrateSqlDbToOrmDb();
            }
        }

        public static void MigrateSqlDbStructure(string sqlConnectionString)
        {
            var migrationsAssembly = typeof(Program).Assembly;

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                var databaseProvider = new MysqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);
                migrator.Load();
                migrator.MigrateTo(2018_10_18_00_25);
            }
        }

        public static void MigrateSqlDbData(string sqlConnectionString)
        {
            var migrationsAssembly = typeof(Program).Assembly;

            using (var connection = new MySqlConnection(sqlConnectionString))
            {
                var databaseProvider = new MysqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);
                migrator.Load();
                migrator.MigrateTo(2018_10_18_00_45);
            }
        }
    }
}