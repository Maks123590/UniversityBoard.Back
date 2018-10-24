namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDepartamentsRepository : IAcademicDepartamentRepository
    {
        private readonly IDbConnection dbConnection;

        public AcademicDepartamentsRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<AcademicDepartament>> GetAll()
        {
            return await this.dbConnection.QueryAsync<AcademicDepartament>(@"SELECT * FROM AcademicDepartaments;");
        }

        public Task<AcademicDepartament> Create(AcademicDepartament entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<AcademicDepartament> Update(AcademicDepartament entity)
        {
            throw new System.NotImplementedException();
        }
    }
}