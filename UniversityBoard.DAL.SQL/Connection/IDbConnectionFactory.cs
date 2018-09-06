namespace UniversityBoard.DAL.SQL.Connection
{
    using System.Data;

    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}