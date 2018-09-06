namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IEducationalDirectionRepository : IRepository<EducationalDirection>, IRepository<int, EducationalDirection>
    {
    }
}