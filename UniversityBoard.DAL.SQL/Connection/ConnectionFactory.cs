namespace UniversityBoard.DAL.SQL.Connection
{
    using System.Data;
    using System.Data.SqlClient;

    public class ConnectionFactory : IDbConnectionFactory
    {
        private readonly string connectionString;

        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(this.connectionString);
        }
    }
}