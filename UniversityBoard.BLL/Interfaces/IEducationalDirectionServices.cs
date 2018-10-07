namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.EducationalDirection;

    public interface IEducationalDirectionServices
    {
        Task<IEnumerable<EducationalDirectionBaseDto>> GetAll();
    }
}