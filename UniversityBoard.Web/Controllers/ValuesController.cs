namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos;
    using UniversityBoard.BLL.Interfaces;
    using UniversityBoard.DAL.Common.Interfaces;

    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IStudentServices studentServices;

        public StudentsController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            return await this.studentServices.GetAllStudents();
        }
    }
}
