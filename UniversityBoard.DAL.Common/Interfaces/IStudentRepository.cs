namespace UniversityBoard.DAL.Common.Interfaces
{
    using UniversityBoard.DAL.Common.Models;

    public interface IStudentRepository : IRepository<Student>, IRepository<int, Student>
    {
    }
}