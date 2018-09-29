namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.ExamInfo;
    using UniversityBoard.BLL.Dtos.Group;

    public interface IExamInfoServices
    {
        Task<IEnumerable<ExamInfoDto>> GetByStudentId(int id);

        Task<ExamGroupInfoDto> GetByGroupAndDisciplineCode(int groupId, string disciplineCode);

        Task<ExamInfoDto> Get(int id);

        Task<ExamInfoDto> Create(ExamInfoCreateDto examInfo);

        Task<ExamInfoDto> Update(ExamInfoUpdateDto examInfo);

        Task Delete(int id);
    }
}