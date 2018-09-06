namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IAcademicDisciplineRepository : IRepository<AcademicDiscipline>, IRepository<int, AcademicDiscipline>
    {
    }
}