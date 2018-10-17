namespace UniversityBoard.DAL.ORM.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;


    public class AcademicDisciplineOrmRepository : BaseOrmRepository<string, AcademicDiscipline>, IAcademicDisciplineRepository
    {
        public AcademicDisciplineOrmRepository(DbContext context) : base(context)
        {
        }

        public Task<IEnumerable<AcademicDiscipline>> GetByAcademicDepartamentCode(int code)
        {
            throw new System.NotImplementedException();
        }
    }
}