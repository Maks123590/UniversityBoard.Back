namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentCardsRepository : IStudentCardRepository
    {
        private readonly IDbConnection connection;

        public StudentCardsRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<StudentCard> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<StudentCard>(@"SELECT * FROM StudentCards where Number = @Number", new { Number = id });
        }

        public async Task<StudentCard> Create(StudentCard studentCard)
        {
            return await this.connection.QueryFirstAsync<StudentCard>(
                       @" INSERT INTO StudentCards (Number, IssueDate) VALUES(@Number, @IssueDate);
                          SELECT * FROM StudentCards where Number = LAST_INSERT_ID();",
                       studentCard);
        }

        public async Task<StudentCard> Upsert(StudentCard studentCard)
        {
            return await this.connection.QueryFirstAsync<StudentCard>(
                       @"INSERT INTO StudentCards (Number,IssueDate) 
                            VALUES (@Number, @IssueDate) 
                         ON DUPLICATE KEY UPDATE Number=@Number, IssueDate=@IssueDate;
                         SELECT * FROM StudentCards where Number = @Number;",
                       studentCard);
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM StudentCards WHERE Number = @Number", new { Number = id });
        }
    }
}