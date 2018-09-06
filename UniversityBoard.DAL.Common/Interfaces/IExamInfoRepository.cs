namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IExamInfoRepository : IRepository<ExamInfo>, IRepository<int, ExamInfo>
    {
    }
}