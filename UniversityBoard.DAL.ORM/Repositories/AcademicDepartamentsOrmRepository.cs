namespace UniversityBoard.DAL.ORM.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDepartamentsOrmRepository : BaseOrmRepository<int, AcademicDepartament>, IAcademicDepartamentRepository
    {
        public AcademicDepartamentsOrmRepository(DbContext context)
            : base(context)
        {
        }
    }
}