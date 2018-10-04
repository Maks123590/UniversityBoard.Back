namespace UniversityBoard.DAL.ORM.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class EducationalDiresctionOrmRepository : BaseOrmRepository<string, EducationalDirection>, IEducationalDirectionRepository
    {
        public EducationalDiresctionOrmRepository(DbContext context) : base(context)
        {
        }
    }
}