namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.DAL.Common.Models;

    public interface IAcademicDisciplineService
    {
        Task<IEnumerable<AcademicDisciplineBaseDto>> GetAll();

        Task<AcademicDisciplineDto> Create(AcademicDisciplineCreateDto entity);

        Task<AcademicDisciplineDto> Update(AcademicDisciplineUpdateDto entity);

        Task<AcademicDisciplineDto> Get(string id);

        Task Delete(string id);

        Task<IEnumerable<AcademicDisciplineDto>> GetByGroup(int groupId);
    }
}