namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Dtos.ExamInfo;
    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoServices : IExamInfoServices
    {
        private readonly IExamInfoRepository examInfoRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IAcademicDisciplineRepository academicDisciplineRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IAttestationRepository attestationRepository;

        public ExamInfoServices(
            IExamInfoRepository examInfoRepository,
            IGroupRepository groupRepository,
            IAcademicDisciplineRepository academicDisciplineRepository,
            IStudentRepository studentRepository,
            IAttestationRepository attestationRepository)
        {
            this.examInfoRepository = examInfoRepository;
            this.groupRepository = groupRepository;
            this.academicDisciplineRepository = academicDisciplineRepository;
            this.attestationRepository = attestationRepository;
            this.studentRepository = studentRepository;
        }

        public async Task<OneStudentExamInfosDto> GetByStudentId(int id)
        {
            var examModels = (await this.examInfoRepository.GetByStudentId(id)).Adapt<List<ExamInfoDto>>();

            foreach (var examModel in examModels)
            {
                var attestation = await this.attestationRepository.Get(examModel.AttestationId);

                examModel.AcademicDiscipline = (await this.academicDisciplineRepository.Get(attestation.AcademicDisciplineCode)).Adapt<AcademicDisciplineDto>();

                examModel.AppraisalType = attestation.AppraisalType;
            }

            var student = await this.studentRepository.Get(id);

            return new OneStudentExamInfosDto
                       {
                           Student = student.Adapt<StudentBaseDto>(),
                           ExamInfoList = examModels.OrderByDescending(e => e.Date)
                       };
        }

        public async Task<ExamInfoBaseDto> Get(int id)
        {
            var examModel = await this.examInfoRepository.Get(id);

            await this.AddRelatedEntities(examModel);

            return examModel.Adapt<ExamInfoDto>();
        }

        public async Task<ExamInfoBaseDto> Create(ExamInfoCreateDto examInfo)
        {
            var forCreate = examInfo.Adapt<ExamInfo>();

            forCreate.Level = this.GetLevel(examInfo.Score);

            var newExamInfo = await this.examInfoRepository.Create(forCreate);

            await this.AddRelatedEntities(newExamInfo);

            return newExamInfo.Adapt<ExamInfoDto>();
        }

        public async Task<ExamInfoBaseDto> Update(ExamInfoUpdateDto examInfo)
        {
            var forUpdate = examInfo.Adapt<ExamInfo>();

            forUpdate.Level = this.GetLevel(examInfo.Score);

            var updatedExamInfo = await this.examInfoRepository.Update(forUpdate);

            await this.AddRelatedEntities(updatedExamInfo);

            return updatedExamInfo.Adapt<ExamInfoDto>();
        }

        public async Task Delete(int id)
        {
            await this.examInfoRepository.Delete(id);
        }

        private async Task AddRelatedEntities(ExamInfo examInfo)
        {
            examInfo.Attestation = await this.attestationRepository.Get(examInfo.AttestationId);
            examInfo.Student = await this.studentRepository.Get(examInfo.StudentId);
        }

        private int GetLevel(int score)
        {
            if (score == 0)
            {
                return 0;
            }

            if (score < 52)
            {
                return 2;
            }

            if (score < 72)
            {
                return 3;
            }

            return score < 86 ? 4 : 5;
        }
    }
}