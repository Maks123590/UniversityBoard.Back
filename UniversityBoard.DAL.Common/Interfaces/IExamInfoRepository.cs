namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.DAL.Common.Models;

    public interface IExamInfoRepository : IRepository<ExamInfo>, IRepository<int, ExamInfo>
    {
        Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineCode(int groupId, string disciplineCode);

        Task<IEnumerable<ExamInfo>> GetByStudentId(int id);
    }
}