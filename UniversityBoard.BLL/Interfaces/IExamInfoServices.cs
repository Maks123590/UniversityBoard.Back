namespace UniversityBoard.BLL.Interfaces
{
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.ExamInfo;

    public interface IExamInfoServices
    {
        Task<OneStudentExamInfosDto> GetByStudentId(int id);

        Task<ExamGroupInfoDto> GetByGroupAndDisciplineCode(int groupId, string disciplineCode);

        Task<ExamInfoDto> Get(int id);

        Task<ExamInfoDto> Create(ExamInfoCreateDto examInfo);

        Task<ExamInfoDto> Update(ExamInfoUpdateDto examInfo);

        Task Delete(int id);
    }
}