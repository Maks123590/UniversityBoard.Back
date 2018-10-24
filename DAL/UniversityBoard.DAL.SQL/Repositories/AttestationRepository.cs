namespace UniversityBoard.DAL.SQL.Repositories
{
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    using Dapper;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AttestationRepository : IAttestationRepository
    {
        private readonly IDbConnection connection;

        public AttestationRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Attestation>> GetAll()
        {
            return await this.connection.QueryAsync<Attestation>(@"SELECT * FROM Attestations;");
        }

        public async Task<Attestation> Create(Attestation entity)
        {
            return await this.connection.QueryFirstAsync<Attestation>(
                       @"INSERT INTO Attestations (Date, AcademicDisciplineCode, GroupId, HoursCount, AppraisalType ) 
					 VALUES(@Date, @AcademicDisciplineCode, @GroupId, @HoursCount, @AppraisalType);
                          SELECT * FROM Attestations where Id = LAST_INSERT_ID();",
                       entity);
        }

        public async Task<Attestation> Update(Attestation entity)
        {
            return await this.connection.QueryFirstAsync<Attestation>(
                       @"UPDATE Attestations
                           SET Date = @Date,
                          AcademicDisciplineCode = @AcademicDisciplineCode,
                           GroupId = @GroupId,
                           HoursCount = @HoursCount,
                           AppraisalType = @AppraisalType
                        WHERE Id = @id;

                        SELECT * FROM Attestations where Id = @id",
                       entity);
        }

        public async Task<Attestation> Get(int id)
        {
            return await this.connection.QueryFirstOrDefaultAsync<Attestation>(@"SELECT * FROM Attestations where Id = @id", new { id });
        }

        public async Task Delete(int id)
        {
            await this.connection.ExecuteAsync(@"DELETE FROM Attestations WHERE Id = @id", new { id });
        }

        public Task<IEnumerable<Attestation>> GetByGroup(int groupId)
        {
            return this.connection.QueryAsync<Attestation>(@"SELECT * FROM Attestations WHERE GroupId = @groupId;", new { groupId });
        }
    }
}