namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Dtos.StudentCard;
    using UniversityBoard.BLL.Interfaces;
    
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentServices studentServices;
        private readonly IStudentCardServices studentCardServices;

        public StudentsController(IStudentServices studentServices, IStudentCardServices studentCardServices)
        {
            this.studentServices = studentServices;
            this.studentCardServices = studentCardServices;
        }
        
        /// <summary>
        /// Возвращает полный список студентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            return await this.studentServices.GetAllStudents();
        }

        /// <summary>
        /// Возвращает студента по идентификатору
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<StudentDto> Get([FromRoute]int id)
        {
            return await this.studentServices.Get(id);
        }

        /// <summary>
        /// Создает нового студента
        /// </summary>
        /// <param name="student">Модель студента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<StudentDto> Create([FromBody]StudentCreateDto student)
        {
            return await this.studentServices.Create(student);
        }

        /// <summary>
        /// Обновляет информацию о студенте
        /// </summary>
        /// <param name="student">Модель студента</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<StudentDto> Update([FromBody]StudentUpdateDto student)
        {
            return await this.studentServices.Update(student);
        }

        /// <summary>
        /// Удаляет студента
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task Delete([FromRoute]int id)
        {
            await this.studentServices.Delete(id);
        }

        #region StudentCard

        /// <summary>
        /// Получает студенческий билет по его номеру
        /// </summary>
        /// <param name="number">Номер студенческого билета</param>
        /// <returns></returns>
        [HttpGet("studentCard/{id:int}")]
        public async Task<StudentCardDto> GetByNumber(int number)
        {
            return await this.studentCardServices.GetStudentCard(number);
        }

        /// <summary>
        /// Удаляет студенческий билет
        /// </summary>
        /// <param name="number">Номер студенческого билета</param>
        /// <returns></returns>
        [HttpDelete("studentCard/{id:int}")]
        public async Task DeleteStudentCard(int number)
        {
            await this.studentCardServices.DeleteCard(number);
        }

        #endregion
    }
}
