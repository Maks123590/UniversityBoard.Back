namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.ExamInfo;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamInfoServices examInfoServices;

        public ExamsController(IExamInfoServices examInfoServices)
        {
            this.examInfoServices = examInfoServices;
        }

        /// <summary>
        /// Возвращает информацию по всем экзаменам определенного студента
        /// </summary>
        /// <returns></returns>
        [HttpGet("student/{id:int}")]
        public async Task<OneStudentExamInfosDto> GetByStudentId(int id)
        {
            return await this.examInfoServices.GetByStudentId(id);
        }

        /// <summary>
        /// Возвращает сводную информацию об экзамене по определенному предмету в одной группе
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <param name="disciplineCode">Код дисциплины</param>
        /// <returns></returns>
        [HttpGet("{groupId:int}/{disciplineCode}")]
        public async Task<ExamGroupInfoDto> GetByGroupAndDisciplineId(int groupId, string disciplineCode)
        {
            return await this.examInfoServices.GetByGroupAndDisciplineCode(groupId, disciplineCode);
        }

        /// <summary>
        /// Возвращает информацию об экзамене по ее идентификатору
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ExamInfoDto> Get(int id)
        {
            return await this.examInfoServices.Get(id);
        }

        /// <summary>
        /// Создает информацию об сдаче экзамена
        /// </summary>
        [HttpPost]
        public async Task<ExamInfoDto> Create(ExamInfoCreateDto examInfo)
        {
            return await this.examInfoServices.Create(examInfo);
        }

        /// <summary>
        /// Обновляет информацию об сдаче экзамена
        /// </summary>
        [HttpPut]
        public async Task<ExamInfoDto> Update(ExamInfoUpdateDto examInfo)
        {
            return await this.examInfoServices.Update(examInfo);
        }

        /// <summary>
        /// Удаляет информацию об сдаче экзамена
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.examInfoServices.Delete(id);
        }
    }
}
