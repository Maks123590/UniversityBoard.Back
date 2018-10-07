namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.EducationalDirection;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class EducationalDirectionsController : ControllerBase
    {
        private readonly IEducationalDirectionServices educationalDirectionServices;

        public EducationalDirectionsController(IEducationalDirectionServices educationalDirectionServices)
        {
            this.educationalDirectionServices = educationalDirectionServices;
        }

        /// <summary>
        /// Возвращает список всех направлений
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<EducationalDirectionBaseDto>> GetAll()
        {
            return await this.educationalDirectionServices.GetAll();
        }
    }
}