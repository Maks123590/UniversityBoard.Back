namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDisciplineNoSqlRepository : NoSqlRepositoryBase<string, AcademicDiscipline>, IAcademicDisciplineRepository
    {
        public AcademicDisciplineNoSqlRepository(IMongoCollection<AcademicDiscipline> collection)
            : base(collection, nameof(AcademicDiscipline.DisciplineCode))
        {
        }

        public async Task<AcademicDiscipline> Update(AcademicDiscipline entity)
        {
            return await base.Update(entity.DisciplineCode, entity);
        }

        public async Task<IEnumerable<AcademicDiscipline>> GetByAcademicDepartamentCode(int code)
        {
            var filter = Builders<AcademicDiscipline>.Filter.Eq(this.idName, code);

            return await this.collection.Find(filter).ToListAsync();
        }
    }
}