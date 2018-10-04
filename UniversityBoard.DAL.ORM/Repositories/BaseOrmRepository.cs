namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;

    public abstract class BaseOrmRepository<TKey, TEntity> : IRepository<TEntity>, IRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseOrmRepository(DbContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var newEntity = await this.DbSet.AddAsync(entity);

            await this.Context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Get(TKey id)
        {
            return await this.DbSet.FindAsync(id);
        }

        public async Task Delete(TKey id)
        {
            var entity = await this.DbSet.FindAsync(id);

            this.DbSet.Remove(entity);

            await this.Context.SaveChangesAsync();
        }
    }
}