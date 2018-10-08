namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.AcademicDepartament;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class AcademicDepartamentsController : ControllerBase
    {
        private readonly IAcademicDepartamentService academicDepartamentService;

        public AcademicDepartamentsController(IAcademicDepartamentService academicDepartamentService)
        {
            this.academicDepartamentService = academicDepartamentService;
        }

        /// <summary>
        /// Возвращает все кафедры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AcademicDepartamentBaseDto>> GetAll()
        {
            return await this.academicDepartamentService.GetAll();
        }
    }
}