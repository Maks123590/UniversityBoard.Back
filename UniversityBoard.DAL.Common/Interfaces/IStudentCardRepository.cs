namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Threading.Tasks;

    using UniversityBoard.DAL.Common.Models;

    public interface IStudentCardRepository : IRepository<int, StudentCard>
    {
        Task<StudentCard> Create(StudentCard studentCard);

        Task<StudentCard> Upsert(StudentCard studentCard);
    }
}