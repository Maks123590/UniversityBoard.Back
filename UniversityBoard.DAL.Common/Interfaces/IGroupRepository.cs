namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IGroupRepository : IRepository<Group>, IRepository<int, Group>
    {
    }
}