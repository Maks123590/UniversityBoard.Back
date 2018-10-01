namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityBoard.DAL.Common.Models;

    public interface IAcademicDisciplineRepository : IRepository<AcademicDiscipline>, IRepository<string, AcademicDiscipline>
    {
        Task<IEnumerable<AcademicDiscipline>> GetByGroup(int groupId);
    }
}