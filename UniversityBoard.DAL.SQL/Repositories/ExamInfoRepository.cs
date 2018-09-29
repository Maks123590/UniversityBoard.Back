using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityBoard.DAL.Common.Interfaces;
using UniversityBoard.DAL.Common.Models;

namespace UniversityBoard.DAL.SQL.Repositories
{
    public class ExamInfoRepository: IExamInfoRepository
    {
        public Task<IEnumerable<ExamInfo>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ExamInfo> Create(ExamInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ExamInfo> Update(ExamInfo entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ExamInfo> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ExamInfo>> GetByGroupAndDisciplineId(int groupId, int disciplineId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ExamInfo>> GetByStudentId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}