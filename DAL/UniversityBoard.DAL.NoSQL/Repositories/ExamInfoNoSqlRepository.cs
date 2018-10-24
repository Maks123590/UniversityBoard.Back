namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoNoSqlRepository : NoSqlRepositoryBase<int, ExamInfo>, IExamInfoRepository
    {
        public ExamInfoNoSqlRepository(IMongoCollection<ExamInfo> collection)
            : base(collection, nameof(ExamInfo.Id))
        {
        }

        public async Task<ExamInfo> Update(ExamInfo entity)
        {
            return await base.Update(entity.Id, entity);
        }

        public async Task<IEnumerable<ExamInfo>> GetByStudentId(int id)
        {
            var filter = Builders<ExamInfo>.Filter.Eq(nameof(ExamInfo.StudentId), id);

            return await this.collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<ExamInfo>> GetByAttestationId(int id)
        {
            var filter = Builders<ExamInfo>.Filter.Eq(nameof(ExamInfo.AttestationId), id);

            return await this.collection.Find(filter).ToListAsync();
        }
    }
}