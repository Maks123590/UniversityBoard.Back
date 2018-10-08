namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.AcademicDiscipline;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class AcademicDisciplinesController : ControllerBase
    {
        private readonly IAcademicDisciplineService academicDisciplineService;

        public AcademicDisciplinesController(IAcademicDisciplineService academicDisciplineService)
        {
            this.academicDisciplineService = academicDisciplineService;
        }

        /// <summary>
        /// Возвращает список всех дисциплин
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AcademicDisciplineBaseDto>> GetAll()
        {
            return await this.academicDisciplineService.GetAll();
        }

        /// <summary>
        /// Создает новую дисциплину
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AcademicDisciplineDto> Create(AcademicDisciplineCreateDto entity)
        {
            return await this.academicDisciplineService.Create(entity);
        }

        /// <summary>
        /// Обновляет информацию о дисциплине
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<AcademicDisciplineDto> Update(AcademicDisciplineUpdateDto entity)
        {
            return await this.academicDisciplineService.Update(entity);
        }

        /// <summary>
        /// Получает дисциплину по коду
        /// </summary>
        /// <param name="code">код дисциплины</param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public async Task<AcademicDisciplineDto> Get(string code)
        {
            return await this.academicDisciplineService.Get(code);
        }

        /// <summary>
        /// Удаляет дисциплину по ее коду
        /// </summary>
        /// <param name="code">код дисциплины</param>
        /// <returns></returns>
        [HttpDelete("{code}")]
        public async Task Delete(string code)
        {
            await this.academicDisciplineService.Delete(code);
        }

        /// <summary>
        /// Возвращает дисциплины по идентификатору группы
        /// </summary>
        /// <param name="groupId">идентификатор группы</param>
        /// <returns></returns>
        [HttpGet("byGroup/{groupId:int}")]
        public async Task<IEnumerable<AcademicDisciplineDto>> GetByGroup(int groupId)
        {
            return await this.academicDisciplineService.GetByGroup(groupId);
        }

        /// <summary>
        /// Возвращает дисциплины по коду кафедры
        /// </summary>
        /// <param name="code">код кафедры</param>
        /// <returns></returns>
        [HttpGet("byAcademicDepartament/{code:int}")]
        public async Task<IEnumerable<AcademicDisciplineDto>> GetByAcademicDepartament(int code)
        {
            return await this.academicDisciplineService.GetByAcademicDepartamentCode(code);
        }
    }
}