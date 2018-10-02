namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoRepository : IExamInfoRepository
    {
        private readonly IDbConnection connection;

        public ExamInfoRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<ExamInfo>> GetAll()
        {
            return await this.connection.QueryAsync<ExamInfo>(@"SELECT * FROM ExamInfos;");
        }

        public async Task<ExamInfo> Create(ExamInfo entity)
        {
            return await this.connection.QueryFirstAsync<ExamInfo>(
                       @"INSERT INTO ExamInfos (Date, AcademicDisciplineCode, StudentId, HoursCount, AppraisalType, Score, GroupId, Level, SetOff) 
					 VALUES(@Date, @AcademicDisciplineCode, @StudentId, @HoursCount, @AppraisalType, @Score, @GroupId, @Level, @SetOff);
                          SELECT * FROM ExamInfos where Id = LAST_INSERT_ID();",
                       entity);
        }

        public async Task<ExamInfo> Update(ExamInfo entity)
        {
            return await this.connection.QueryFirstAsync<ExamInfo>(
                       @"UPDATE ExamInfos
                           SET Date = @Date,
                          AcademicDisciplineCode = @AcademicDisciplineCode,
                           StudentId = @StudentId,
                           HoursCount = @HoursCount,
                           AppraisalType = @AppraisalType,
                           Score = @Score,
                           GroupId = @GroupId,
                           Level = @Level,
                           SetOff = @SetOff
                        WHERE Id = @id;

                        SELECT * FROM ExamInfos where Id = @id",
                       entity);
        }

        public async Task<ExamInfo> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<ExamInfo>(@"SELECT * FROM ExamInfos where Id = @id", new { id });
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM ExamInfos WHERE Id = @id", new { id });
        }

        public Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineCode(int groupId, string disciplineCode)
        {
            return this.connection.QueryAsync<ExamInfo>(@"SELECT * FROM ExamInfos WHERE GroupId = @groupId and AcademicDisciplineCode = @disciplineCode;", new { groupId, disciplineCode });
        }

        public Task<IEnumerable<ExamInfo>> GetByStudentId(int id)
        {
            return this.connection.QueryAsync<ExamInfo>(@"SELECT * FROM ExamInfos WHERE StudentId = @id;", new { id });
        }
    }
}