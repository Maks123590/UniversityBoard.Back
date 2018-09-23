namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class EducationalDirectionRepository : IEducationalDirectionRepository
    {
        private readonly IDbConnection connection;

        public EducationalDirectionRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<EducationalDirection>> GetAll()
        {
            return await this.connection.QueryAsync<EducationalDirection>(@"SELECT * FROM EducationalDirections;");
        }

        public async Task<EducationalDirection> Create(EducationalDirection entity)
        {
            return await this.connection.QueryFirstAsync<EducationalDirection>(
                       @" INSERT INTO EducationalDirections (Code, Name) VALUES(@Code, @Name);
                          SELECT * FROM StudentCards where Code = @Code;",
                       entity);
        }

        public async Task<EducationalDirection> Update(EducationalDirection entity)
        {
            return await this.connection.QueryFirstAsync<EducationalDirection>(
                       @"UPDATE EducationalDirections
                            SET Code = @Code,
	                        Name = @Name
                         WHERE Code = @Code;

                         SELECT * FROM Groups where id = @id",
                       entity);
        }

        public async Task<EducationalDirection> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<EducationalDirection>(@"SELECT * FROM EducationalDirections where Code = @Code", new { Code = id });
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM StudentCards WHERE Code = @Code", new { Number = id });
        }
    }
}