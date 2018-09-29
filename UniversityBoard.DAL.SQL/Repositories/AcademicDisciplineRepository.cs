namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDisciplineRepository : IAcademicDisciplineRepository
    {
        private readonly IDbConnection dbConnection;

        public AcademicDisciplineRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<AcademicDiscipline>> GetAll()
        {
            return await this.dbConnection.QueryAsync<AcademicDiscipline>(@"SELECT * FROM AcademicDisciplines;");
        }

        public Task<AcademicDiscipline> Create(AcademicDiscipline entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<AcademicDiscipline> Update(AcademicDiscipline entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<AcademicDiscipline> Get(string id)
        {
            return await this.dbConnection.QuerySingleAsync<AcademicDiscipline>(@"SELECT * FROM AcademicDisciplines WHERE DisciplineCode = @id;", new { id });
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}