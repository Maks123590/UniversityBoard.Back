namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AttestationNoSqlRepository : NoSqlRepositoryBase<int, Attestation>, IAttestationRepository
    {
        public AttestationNoSqlRepository(IMongoCollection<Attestation> collection)
            : base(collection, nameof(Attestation.Id))
        {
        }

        public async Task<Attestation> Update(Attestation entity)
        {
            return await base.Update(entity.Id, entity);
        }

        public async Task<IEnumerable<Attestation>> GetByGroup(int groupId)
        {
            var filter = Builders<Attestation>.Filter.Eq(nameof(Attestation.GroupId), groupId);

            return await this.collection.Find(filter).ToListAsync();
        }
    }
}