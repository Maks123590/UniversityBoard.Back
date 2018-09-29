namespace UniversityBoard.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Mapster;

    using UniversityBoard.BLL.Dtos.ExamInfo;
    using UniversityBoard.BLL.Dtos.Group;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class ExamInfoServices : IExamInfoServices
    {
        private readonly IExamInfoRepository examInfoRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IAcademicDisciplineRepository academicDisciplineRepository;

        public ExamInfoServices(IExamInfoRepository examInfoRepository, IGroupRepository groupRepository, IAcademicDisciplineRepository academicDisciplineRepository)
        {
            this.examInfoRepository = examInfoRepository;
            this.groupRepository = groupRepository;
            this.academicDisciplineRepository = academicDisciplineRepository;
        }

        public async Task<IEnumerable<ExamInfoDto>> GetByStudentId(int id)
        {
            var examModels = await this.examInfoRepository.GetByStudentId(id);

            foreach (var examModel in examModels)
            {
                await this.AddRelatedEntities(examModel);
            }

            return examModels.Adapt<IEnumerable<ExamInfoDto>>();
        }

        public async Task<ExamGroupInfoDto> GetByGroupAndDisciplineCode(int groupId, string disciplineCode)
        {
            var examInfos = (await this.examInfoRepository.GetByGroupAndDisciplineCode(groupId, disciplineCode)).Adapt<IEnumerable<ExamInfoDto>>().ToArray();

            var groupInfo = new ExamGroupInfoDto
            {
                Group = (await this.groupRepository.Get(groupId)).Adapt<GroupBaseDto>(),
                ExamInfos = examInfos,
            };

            int GetScoreCount(int score) => examInfos.Count(e => e.Score == score);

            groupInfo.ScoreStatistics = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("Отлично", GetScoreCount(5)),
                new KeyValuePair<string, int>("Хорошо", GetScoreCount(4)),
                new KeyValuePair<string, int>("Удовлетворительно", GetScoreCount(3)),
                new KeyValuePair<string, int>("Не зачтено", examInfos.Length - GetScoreCount(5) - GetScoreCount(4) - GetScoreCount(3)),
            };

            return groupInfo;
        }

        public async Task<ExamInfoDto> Get(int id)
        {
            var examModel = await this.examInfoRepository.Get(id);

            await this.AddRelatedEntities(examModel);

            return examModel.Adapt<ExamInfoDto>();
        }

        public async Task<ExamInfoDto> Create(ExamInfoCreateDto examInfo)
        {
            var forCreate = examInfo.Adapt<ExamInfo>();

            var newExamInfo = await this.examInfoRepository.Create(forCreate);

            await this.AddRelatedEntities(newExamInfo);

            return newExamInfo.Adapt<ExamInfoDto>();
        }

        public async Task<ExamInfoDto> Update(ExamInfoUpdateDto examInfo)
        {
            var forUpdate = examInfo.Adapt<ExamInfo>();

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
            examInfo.AcademicDiscipline = await this.academicDisciplineRepository.Get(examInfo.AcademicDisciplineCode);
        }
    }
}