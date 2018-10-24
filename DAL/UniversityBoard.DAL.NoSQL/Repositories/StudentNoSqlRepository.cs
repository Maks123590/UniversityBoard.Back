namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;
    using UniversityBoard.DAL.Common.Models;

    public class StudentNoSqlRepository : NoSqlRepositoryBase<int, Student>, IStudentRepository
    {
        public StudentNoSqlRepository(IMongoCollection<Student> collection)
            : base(collection, nameof(Student.Id))
        {
        }

        public async Task<Student> Update(Student entity)
        {
            return await base.Update(entity.Id, entity);
        }

        public async Task<IEnumerable<Student>> GetByGroupId(int groupId)
        {
            var filter = Builders<Student>.Filter.Eq(nameof(Student.GroupId), groupId);

            return await this.collection.Find(filter).ToListAsync();
        }
    }
}