namespace UniversityBoard.DAL.NoSQL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using UniversityBoard.DAL.Common.Interfaces;

    public abstract class NoSqlRepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> collection;
        protected readonly string idName;

        protected NoSqlRepositoryBase(IMongoCollection<TEntity> collection, string idName)
        {
            this.collection = collection;
            this.idName = idName;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.collection.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var query = Query.And(Query.EQ("_id", keyName));
            var sortBy = SortBy.Null;
            var update = Update.Inc("KeyValue", adjustmentAmount);
            var result = collection.FindAndModify(query, sortBy, update, true);


            await this.collection.InsertOneAsync(entity);

            return entity;
        }

        public async Task<TEntity> Get(TKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq(this.idName, id);

            return await this.collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task Delete(TKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq(this.idName, id);

            await this.collection.DeleteOneAsync(filter);
        }

        protected async Task<TEntity> Update(TKey id, TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(this.idName, id);

            var result = await this.collection.ReplaceOneAsync(filter, entity);

            if (result.IsAcknowledged)
            {
                return entity;
            }

            throw new Exception($"Update filed for {entity.ToString()} with id: {id}");
        }
    }
}