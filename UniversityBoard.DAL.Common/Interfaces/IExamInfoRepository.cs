using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IExamInfoRepository : IRepository<ExamInfo>, IRepository<int, ExamInfo>
    {
        Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineId(int groupId, int disciplineId);

        Task<IEnumerable<ExamInfo>> GetByStudentId(int id);
    }
}