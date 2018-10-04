namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentCardOrmRepository : BaseOrmRepository<int, StudentCard>, IStudentCardRepository
    {
        public StudentCardOrmRepository(DbContext context) : base(context)
        {
        }

        public Task<StudentCard> Upsert(StudentCard studentCard)
        {
            throw new System.NotImplementedException();
        }
    }
}