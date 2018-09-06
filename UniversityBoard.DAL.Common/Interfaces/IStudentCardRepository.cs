namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IStudentCardRepository : IRepository<StudentCard>, IRepository<int, StudentCard>
    {
    }
}