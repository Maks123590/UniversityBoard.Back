namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class GroupRepository : IGroupRepository
    {
        private readonly IDbConnection connection;

        public GroupRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await this.connection.QueryAsync<Group>(@"SELECT * FROM Groups;");
        }

        public async Task<Group> Create(Group entity)
        {
            return await this.connection.QueryFirstAsync<Group>(
                       @" INSERT INTO Groups (Number, HeadId, FormationDate, EducationalDirectionCode) VALUES(@Number, @HeadId, @FormationDate, @EducationalDirectionCode);
                          SELECT * FROM Groups where id = LAST_INSERT_ID();",
                      entity);
        }

        public async Task<Group> Update(Group entity)
        {
            return await this.connection.QueryFirstAsync<Group>(
                       @"UPDATE Groups
                            SET Number = @Number,
	                        HeadId = @HeadId,
                            FormationDate = @FormationDate,
                            EducationalDirectionCode = @EducationalDirectionCode
                         WHERE id = @id;

                         SELECT * FROM Groups where id = @id",
                       entity);
        }

        public async Task<Group> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<Group>(@"SELECT * FROM Groups where id = @id", new { id });
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM Groups WHERE id = @id", new { id });
        }
    }
}