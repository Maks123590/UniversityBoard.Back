namespace UniversityBoard.DAL.ORM.Repositories
{
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

        public async Task<IEnumerable<AcademicDiscipline>> GetByGroup(int groupId)
        {
            var examInfos = this.Context.Set<ExamInfo>();

            return await this.DbSet.Join(
                       examInfos,
                       discipline => discipline.DisciplineCode,
                       info => info.AcademicDisciplineCode,
                (discipline, info) => new { Discipline = discipline, info.GroupId }).Where(t => t.GroupId == groupId).Select(t => t.Discipline).AsNoTracking().ToListAsync();
        }

        public Task<IEnumerable<AcademicDiscipline>> GetByAcademicDepartamentCode(int code)
        {
            throw new System.NotImplementedException();
        }
    }
}