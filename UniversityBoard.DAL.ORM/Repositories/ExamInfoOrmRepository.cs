namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoOrmRepository : BaseOrmRepository<int, ExamInfo>, IExamInfoRepository
    {
        public ExamInfoOrmRepository(DbContext context) : base(context)
        {
        }

        public Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineCode(int groupId, string disciplineCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ExamInfo>> GetByStudentId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}