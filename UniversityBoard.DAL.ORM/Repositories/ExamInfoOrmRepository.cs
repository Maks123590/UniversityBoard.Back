namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoOrmRepository : BaseOrmRepository<int, ExamInfo>, IExamInfoRepository
    {
        public ExamInfoOrmRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineCode(int groupId, string disciplineCode)
        {
            return await this.DbSet.Where(e => e.GroupId == groupId && e.AcademicDisciplineCode == disciplineCode).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ExamInfo>> GetByStudentId(int id)
        {
            return await this.DbSet.Where(e => e.StudentId == id).AsNoTracking().ToListAsync();
        }
    }
}