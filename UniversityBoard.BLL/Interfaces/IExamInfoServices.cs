namespace UniversityBoard.BLL.Interfaces
{
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.ExamInfo;

    public interface IExamInfoServices
    {
        Task<OneStudentExamInfosDto> GetByStudentId(int id);

        Task<ExamInfoBaseDto> Get(int id);

        Task<ExamInfoBaseDto> Create(ExamInfoCreateDto examInfo);

        Task<ExamInfoBaseDto> Update(ExamInfoUpdateDto examInfo);

        Task Delete(int id);
    }
}