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
            var card = await this.DbSet.FirstOrDefaultAsync(card1 => card1.Number == studentCard.Number);

            StudentCard newCard;

            if (card == null)
            {
                newCard = (await this.DbSet.AddAsync(studentCard)).Entity;
            }
            else
            {
                this.Context.Entry(studentCard).State = EntityState.Modified;
                newCard = studentCard;
            }

            await this.Context.SaveChangesAsync();

            return newCard;
        }
    }
}