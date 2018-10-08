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

        public async Task<AcademicDiscipline> Create(AcademicDiscipline entity)
        {
            return await this.dbConnection.QueryFirstAsync<AcademicDiscipline>(
                       @"INSERT INTO AcademicDisciplines (DisciplineCode, Name, AcademicDepartamentCode) 
					 VALUES(@DisciplineCode, @Name, @AcademicDepartamentCode);
                          SELECT * FROM AcademicDisciplines where DisciplineCode = LAST_INSERT_ID();",
                       entity);
        }

        public async Task<AcademicDiscipline> Update(AcademicDiscipline entity)
        {
            return await this.dbConnection.QueryFirstAsync<AcademicDiscipline>(
                       @"UPDATE AcademicDisciplines
                           SET DisciplineCode = @DisciplineCode,
                               Name = @Name,
                               AcademicDepartamentCode = @AcademicDepartamentCode,
                        WHERE DisciplineCode = @DisciplineCode;

                        SELECT * FROM AcademicDisciplines where DisciplineCode = @DisciplineCode",
                       entity);
        }

        public async Task<AcademicDiscipline> Get(string id)
        {
            return await this.dbConnection.QuerySingleAsync<AcademicDiscipline>(@"SELECT * FROM AcademicDisciplines WHERE DisciplineCode = @id;", new { id });
        }

        public async Task Delete(string id)
        {
            await this.dbConnection.ExecuteAsync(@"DELETE FROM AcademicDisciplines WHERE DisciplineCode = @DisciplineCode", new { DisciplineCode = id });
        }

        public async Task<IEnumerable<AcademicDiscipline>> GetByGroup(int groupId)
        {
            return await this.dbConnection.QueryAsync<AcademicDiscipline>(
                    @"Select distinct d.DisciplineCode, d.Name, d.AcademicDepartamentCode 
                        from AcademicDisciplines d 
                      inner join ExamInfos e on d.DisciplineCode = e.AcademicDisciplineCode 
                        where e.GroupId = @groupId",
                    new { groupId });
        }

        public async Task<IEnumerable<AcademicDiscipline>> GetByAcademicDepartamentCode(int code)
        {
            return await this.dbConnection.QueryAsync<AcademicDiscipline>(
                       @"SELECT * FROM AcademicDisciplines WHERE AcademicDepartamentCode = @code;",
                       new { code });
        }
    }
}