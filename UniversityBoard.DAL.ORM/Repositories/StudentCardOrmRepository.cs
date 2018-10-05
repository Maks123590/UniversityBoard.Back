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

        public async Task<StudentCard> Upsert(StudentCard studentCard)
        {
            await this.DbSet.AddOrUpdate(studentCard);

            await Context.SaveChangesAsync();

            return await this.DbSet.FirstOrDefaultAsync(card1 => card1.Number == studentCard.Number);
        }
    }
}