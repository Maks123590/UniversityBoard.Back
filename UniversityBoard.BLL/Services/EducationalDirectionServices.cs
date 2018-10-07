namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.EducationalDirection;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;

    public class EducationalDirectionServices : IEducationalDirectionServices
    {
        private readonly IEducationalDirectionRepository educationalDirectionRepository;

        public EducationalDirectionServices(IEducationalDirectionRepository educationalDirectionRepository)
        {
            this.educationalDirectionRepository = educationalDirectionRepository;
        }

        public async Task<IEnumerable<EducationalDirectionBaseDto>> GetAll()
        {
            var disciplines = await this.educationalDirectionRepository.GetAll();

            return disciplines.Adapt<IEnumerable<EducationalDirectionBaseDto>>();
        }
    }
}