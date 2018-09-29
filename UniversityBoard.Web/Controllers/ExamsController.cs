using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityBoard.BLL.Dtos.ExamInfo;
using UniversityBoard.BLL.Interfaces;

namespace UniversityBoard.Web.Controllers
{
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
        public async Task<IEnumerable<ExamInfoDto>> GetByStudentId(int id)
        {
            return await this.examInfoServices.GetByStudentId(id);
        }

        // GET: api/Exams/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Exams
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Exams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
