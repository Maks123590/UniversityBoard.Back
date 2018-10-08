namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AcademicDisciplineService : IAcademicDisciplineService
    {
        private readonly IAcademicDisciplineRepository academicDisciplineRepository;

        public AcademicDisciplineService(IAcademicDisciplineRepository academicDisciplineRepository)
        {
            this.academicDisciplineRepository = academicDisciplineRepository;
        }

        public async Task<IEnumerable<AcademicDisciplineBaseDto>> GetAll()
        {
            var disciplines = await this.academicDisciplineRepository.GetAll();

            return disciplines.Adapt<IEnumerable<AcademicDisciplineBaseDto>>();
        }

        public async Task<AcademicDisciplineDto> Create(AcademicDisciplineCreateDto entity)
        {
            return (await this.academicDisciplineRepository.Create(entity.Adapt<AcademicDiscipline>()))
                .Adapt<AcademicDisciplineDto>();
        }

        public async Task<AcademicDisciplineDto> Update(AcademicDisciplineUpdateDto entity)
        {
            return (await this.academicDisciplineRepository.Update(entity.Adapt<AcademicDiscipline>()))
                .Adapt<AcademicDisciplineDto>();
        }

        public async Task<AcademicDisciplineDto> Get(string id)
        {
            return (await this.academicDisciplineRepository.Get(id)).Adapt<AcademicDisciplineDto>();
        }

        public async Task Delete(string id)
        {
            await this.academicDisciplineRepository.Delete(id);
        }

        public async Task<IEnumerable<AcademicDisciplineDto>> GetByGroup(int groupId)
        {
            return (await this.academicDisciplineRepository.GetByGroup(groupId))
                .Adapt<IEnumerable<AcademicDisciplineDto>>();
        }

        public async Task<IEnumerable<AcademicDisciplineDto>> GetByAcademicDepartamentCode(int code)
        {
            return (await this.academicDisciplineRepository.GetByAcademicDepartamentCode(code))
                .Adapt<IEnumerable<AcademicDisciplineDto>>();
        }
    }
}