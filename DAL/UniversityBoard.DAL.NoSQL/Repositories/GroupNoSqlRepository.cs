namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class GroupNoSqlRepository : NoSqlRepositoryBase<int, Group>, IGroupRepository
    {
        public GroupNoSqlRepository(IMongoCollection<Group> collection)
            : base(collection, nameof(Group.Id))
        {
        }

        public async Task<Group> Update(Group entity)
        {
            return await base.Update(entity.Id, entity);
        }
    }
}