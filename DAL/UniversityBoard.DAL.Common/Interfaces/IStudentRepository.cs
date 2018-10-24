namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.DAL.Common.Models;

    public interface IStudentRepository : IRepository<Student>, IRepository<int, Student>
    {
        Task<IEnumerable<Student>> GetByGroupId(int groupId);
    }
}