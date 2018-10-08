namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.AcademicDepartament;

    public interface IAcademicDepartamentService
    {
        Task<IEnumerable<AcademicDepartamentBaseDto>> GetAll();
    }
}