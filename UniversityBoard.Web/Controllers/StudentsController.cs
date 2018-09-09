namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Dtos.Student;
    using UniversityBoard.BLL.Interfaces;
    
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentServices studentServices;
        
        public StudentsController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
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
    }
}
