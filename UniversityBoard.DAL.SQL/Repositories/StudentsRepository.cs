namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentsRepository : IStudentRepository
    {
        private readonly IDbConnection connection;

        public StudentsRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await this.connection.QueryAsync<Student>(@"SELECT * FROM Students;");
        }

        public async Task<Student> Create(Student entity)
        {
            return await this.connection.QueryFirstAsync<Student>(
                       @" INSERT INTO Students (FirstName, LastName, MiddleName, Gender, BirthDay, StudentCardNumber, StudentCardIssueDate, GroupId) 
                            VALUES(@FirstName, @LastName, @MiddleName, @Gender, @BirthDay, @StudentCardNumber, @StudentCardIssueDate, @GroupId);
                          SELECT * FROM Students where id = LAST_INSERT_ID();",
                       entity);
        }

        public async Task<Student> Update(Student entity)
        {
            return await this.connection.QueryFirstAsync<Student>(
                @"UPDATE Students
                    SET FirstName = @FirstName,
	                     LastName = @LastName,
	                     MiddleName = @MiddleName,
	                     Gender = @Gender,
	                     BirthDay = @BirthDay,
	                     StudentCardNumber = @StudentCardNumber,
                         StudentCardIssueDate = @StudentCardIssueDate,
	                     GroupId = @GroupId
                    WHERE id = @id;

                 SELECT * FROM Students where id = @id",
                entity);
        }

        public async Task<Student> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<Student>(@"SELECT * FROM Students where id = @id", new { id });
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM Students WHERE id = @id", new { id });
        }

        public async Task<IEnumerable<Student>> GetByGroupId(int groupId)
        {
            return await this.connection.QueryAsync<Student>(
                @"SELECT * FROM Students WHERE GroupId = @groupId;",
                new { groupId });
        }
    }
}