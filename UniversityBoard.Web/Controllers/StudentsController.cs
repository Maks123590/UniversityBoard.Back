namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos;
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
        public async Task<IEnumerable<StudentDto>> Get()
        {
            return await this.studentServices.GetAllStudents();
        }
    }
}
