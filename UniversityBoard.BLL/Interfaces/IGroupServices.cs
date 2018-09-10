namespace UniversityBoard.BLL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.BLL.Dtos.Group;

    public interface IGroupServices
    {
        Task<IEnumerable<GroupDto>> GetAllGroups();

        Task<GroupDto> Get(int id);

        Task<GroupDto> Create(GroupCreateDto group);

        Task<GroupDto> Update(GroupUpdateDto group);

        Task Delete(int id);
    }
}