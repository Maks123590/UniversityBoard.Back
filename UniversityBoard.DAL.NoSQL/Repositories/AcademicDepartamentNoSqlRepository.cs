namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDepartamentNoSqlRepository : NoSqlRepositoryBase<int, AcademicDepartament>,
                                                      IRepository<AcademicDepartament>
    {
        public AcademicDepartamentNoSqlRepository(IMongoCollection<AcademicDepartament> collection)
            : base(collection, nameof(AcademicDepartament.Code))
        {
        }

        public async Task<AcademicDepartament> Update(AcademicDepartament entity)
        {
            return await base.Update(entity.Code, entity);
        }
    }
}