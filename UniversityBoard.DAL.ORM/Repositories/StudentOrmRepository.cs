namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;


    public class StudentOrmRepository : BaseOrmRepository<int, Student>, IStudentRepository
    {
        public StudentOrmRepository(DbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Student>> GetByGroupId(int groupId)
        {
            throw new System.NotImplementedException();
        }
    }
}