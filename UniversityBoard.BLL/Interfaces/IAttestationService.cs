namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.AttestationDto;

    public interface IAttestationService
    {
        Task<AttestationDto> Create(AttestationCreateDto entity);

        Task<AttestationDto> Update(AttestationUpdateDto entity);

        Task<AttestationDto> Get(int id);

        Task Delete(int id);

        Task<IEnumerable<AttestationDto>> GetByGroup(int groupId);
    }
}