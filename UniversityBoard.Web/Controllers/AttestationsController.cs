namespace UniversityBoard.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using UniversityBoard.BLL.Dtos.AttestationDto;
    using UniversityBoard.BLL.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class AttestationsController : ControllerBase
    {
        private readonly IAttestationService attestationService;

        public AttestationsController(IAttestationService attestationService)
        {
            this.attestationService = attestationService;
        }

        /// <summary>
        /// Возвращает сводную информацию об экзамене по каждому предмету в одной группе
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns></returns>
        [HttpGet("byGroup/{groupId:int}")]
        public async Task<IEnumerable<AttestationDto>> GetByGroupId(int groupId)
        {
            return await this.attestationService.GetByGroup(groupId);
        }

        /// <summary>
        /// Возвращает информацию об аттестации по ее идентификатору
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<AttestationDto> Get(int id)
        {
            return await this.attestationService.Get(id);
        }

        /// <summary>
        /// Создает информацию об аттестации
        /// </summary>
        [HttpPost]
        public async Task<AttestationDto> Create(AttestationCreateDto attestation)
        {
            return await this.attestationService.Create(attestation);
        }

        /// <summary>
        /// Обновляет информацию об аттестации
        /// </summary>
        [HttpPut]
        public async Task<AttestationDto> Update(AttestationUpdateDto attestation)
        {
            return await this.attestationService.Update(attestation);
        }

        /// <summary>
        /// Удаляет информацию об аттестации
        /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.attestationService.Delete(id);
        }
    }
}