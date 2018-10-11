namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.AttestationDto;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class AttestationService : IAttestationService
    {
        private readonly IAttestationRepository attestationRepository;
        private readonly IExamInfoRepository examInfoRepository;
        private readonly IAcademicDisciplineRepository academicDisciplineRepository;
        private readonly IGroupRepository groupRepository;

        public AttestationService(IAttestationRepository attestationRepository, IExamInfoRepository examInfoRepository, IAcademicDisciplineRepository academicDisciplineRepository, IGroupRepository groupRepository)
        {
            this.attestationRepository = attestationRepository;
            this.examInfoRepository = examInfoRepository;
            this.academicDisciplineRepository = academicDisciplineRepository;
            this.groupRepository = groupRepository;
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

            int GetScoreCount(int score) => examInfos.Count(e => e.Score == score);

            attestationDto.ScoreStatistics = new List<KeyValuePair<string, int>>
                                            {
                                                new KeyValuePair<string, int>("Отлично", GetScoreCount(5)),
                                                new KeyValuePair<string, int>("Хорошо", GetScoreCount(4)),
                                                new KeyValuePair<string, int>("Удовлетворительно", GetScoreCount(3)),
                                                new KeyValuePair<string, int>("Не зачтено", examInfos.Length - GetScoreCount(5) - GetScoreCount(4) - GetScoreCount(3)),
                                            };

            return attestationDto;
        }
    }
}