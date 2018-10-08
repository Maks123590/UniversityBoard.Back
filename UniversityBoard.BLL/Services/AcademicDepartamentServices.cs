namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.AcademicDepartament;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;

    public class AcademicDepartamentServices : IAcademicDepartamentService
    {
        private readonly IAcademicDepartamentRepository academicDepartamentRepository;

        public AcademicDepartamentServices(IAcademicDepartamentRepository academicDepartamentRepository)
        {
            this.academicDepartamentRepository = academicDepartamentRepository;
        }

        public async Task<IEnumerable<AcademicDepartamentBaseDto>> GetAll()
        {
            var disciplines = await this.academicDepartamentRepository.GetAll();

            return disciplines.Adapt<IEnumerable<AcademicDepartamentBaseDto>>();
        }
    }
}