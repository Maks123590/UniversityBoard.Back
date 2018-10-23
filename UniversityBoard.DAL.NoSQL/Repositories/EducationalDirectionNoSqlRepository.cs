namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class EducationalDirectionNoSqlRepository : NoSqlRepositoryBase<string, EducationalDirection>, IEducationalDirectionRepository
    {
        public EducationalDirectionNoSqlRepository(IMongoCollection<EducationalDirection> collection)
            : base(collection, nameof(EducationalDirection.Code))
        {
        }

        public async Task<EducationalDirection> Update(EducationalDirection entity)
        {
            return await base.Update(entity.Code, entity);
        }
    }
}