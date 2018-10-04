namespace UniversityBoard.DAL.ORM.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class GroupOrmRepository : BaseOrmRepository<int, Group>, IGroupRepository
    {
        public GroupOrmRepository(DbContext context) : base(context)
        {
        }
    }
}