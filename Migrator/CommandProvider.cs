namespace Migrator
{
    public static class CommandProvider
    {
        public static void MigrateSqlToOrm(string sqlConnectionString, string entityFrameworkConnectionString)
        {
            using (var migrator = new SqlToOrmMigrator(sqlConnectionString, entityFrameworkConnectionString))
            {
                migrator.MigrateSqlDbToOrmDb();
            }
        }
    }
}