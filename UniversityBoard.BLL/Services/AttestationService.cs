namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.AttestationDto;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Enums;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AttestationService : IAttestationService
    {
        private readonly IAttestationRepository attestationRepository;
        private readonly IExamInfoRepository examInfoRepository;
        private readonly IAcademicDisciplineRepository academicDisciplineRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IStudentRepository studentRepository;

        public AttestationService(
            IAttestationRepository attestationRepository,
            IExamInfoRepository examInfoRepository,
            IAcademicDisciplineRepository academicDisciplineRepository,
            IGroupRepository groupRepository,
            IStudentRepository studentRepository)
        {
            this.attestationRepository = attestationRepository;
            this.examInfoRepository = examInfoRepository;
            this.academicDisciplineRepository = academicDisciplineRepository;
            this.groupRepository = groupRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<AttestationDto> Create(AttestationCreateDto entity)
        {
            var entityModel = entity.Adapt<Attestation>();
            
            var newEntity = await this.attestationRepository.Create(entityModel);

            await this.AddRelatedEntities(newEntity, addExamInfos: true);

            return this.AddScoreStatistics(newEntity.Adapt<AttestationDto>());
        }

        public async Task<AttestationDto> Update(AttestationUpdateDto entity)
        {
            var entityModel = entity.Adapt<Attestation>();

            var changedEntity = await this.attestationRepository.Update(entityModel);

            await this.AddRelatedEntities(changedEntity, addExamInfos: true);

            return this.AddScoreStatistics(changedEntity.Adapt<AttestationDto>());
        }

        public async Task<AttestationDto> Get(int id)
        {
            var attestation = await this.attestationRepository.Get(id);

            await this.AddRelatedEntities(attestation, addExamInfos: true);

            return this.AddScoreStatistics(attestation.Adapt<AttestationDto>());
        }

        public async Task Delete(int id)
        {
            await this.attestationRepository.Delete(id);
        }

        public async Task<IEnumerable<AttestationDto>> GetByGroup(int groupId)
        {
            var attestationModels = await this.attestationRepository.GetByGroup(groupId);

            foreach (var attestation in attestationModels)
            {
                await this.AddRelatedEntities(attestation);
            }

            return attestationModels.Adapt<IEnumerable<AttestationDto>>();
        }

        private async Task AddRelatedEntities(Attestation attestation, bool addAcademicDiscipline = true, bool addGroupInfo = true, bool addExamInfos = false)
        {
            if (addExamInfos)
            {
                attestation.ExamInfos = await this.examInfoRepository.GetByAttestationId(attestation.Id);

                foreach (var a in attestation.ExamInfos)
                {
                    a.Student = await this.studentRepository.Get(a.StudentId);
                }
            }

            if (addAcademicDiscipline)
            {
                attestation.AcademicDiscipline = await this.academicDisciplineRepository.Get(attestation.AcademicDisciplineCode);
            }

            if (addGroupInfo)
            {
                attestation.Group = await this.groupRepository.Get(attestation.GroupId);
            }
        }

        private AttestationDto AddScoreStatistics(AttestationDto attestationDto)
        {
            var examInfos = attestationDto.ExamInfos.ToArray();

            int GetLevelCount(int level) => examInfos.Count(e => e.Level == level);

            if (attestationDto.AppraisalType == AttestationType.Exam)
            {
                attestationDto.ScoreStatistics = new List<StatisticsDto>
                                                     {
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Отлично",
                                                                 Count = GetLevelCount(5),
                                                                 Color = "#f1c40f"
                                                             },
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Хорошо",
                                                                 Count = GetLevelCount(4),
                                                                 Color = "#f39c12"
                                                             },
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Удовлетворительно",
                                                                 Count = GetLevelCount(3),
                                                                 Color = "#3498db"
                                                             },
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Не зачтено",
                                                                 Count = examInfos.Length - GetLevelCount(5) - GetLevelCount(4) - GetLevelCount(3),
                                                                 Color = "#bdc3c7"
                                                             },
                                                     };
            }
            else
            {
                attestationDto.ScoreStatistics = new List<StatisticsDto>
                                                     {
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Зачтено",
                                                                 Count = GetLevelCount(3) + GetLevelCount(4) + GetLevelCount(5),
                                                                 Color = "#f1c40f",
                                                             },
                                                         new StatisticsDto
                                                             {
                                                                 Label = "Не зачтено",
                                                                 Count = examInfos.Length - GetLevelCount(3) - GetLevelCount(4) - GetLevelCount(5),
                                                                 Color = "#bdc3c7",
                                                             },
                                                     };
            }



            return attestationDto;
        }
    }
}