namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.Group;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : Controller
    {
        private readonly IGroupServices groupServices;

        public GroupsController(IGroupServices groupServices)
        {
            this.groupServices = groupServices;
        }

        /// <summary>
        /// Возвращает полный список групп
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<GroupDto>> GetAll()
        {
            return await this.groupServices.GetAllGroups();
        }

        /// <summary>
        /// Возвращает группу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<GroupDto> Get(int id)
        {
            return await this.groupServices.Get(id);
        }

        /// <summary>
        /// Создает новую группу
        /// </summary>
        /// <param name="group"></param>
        [HttpPost]
        public async Task<GroupDto> Post([FromBody] GroupCreateDto group)
        {
            return await this.groupServices.Create(group);
        }

        /// <summary>
        /// Обновляет информацию о группе
        /// </summary>
        [HttpPut]
        public async Task<GroupDto> Put([FromBody] GroupUpdateDto group)
        {
            return await this.groupServices.Update(group);
        }


        /// <summary>
        /// Удаляет группу
        /// </summary>
        /// <param name="id">Идентификатор</param>
        [HttpDelete("{id:int}")]
        public async void Delete(int id)
        {
            await this.groupServices.Delete(id);
        }
    }
}
