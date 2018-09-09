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

        public Task<Student> Create(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> Update(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Student> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}