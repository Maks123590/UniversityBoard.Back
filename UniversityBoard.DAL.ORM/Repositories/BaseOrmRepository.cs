namespace UniversityBoard.DAL.ORM.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using UniversityBoard.DAL.Common.Interfaces;

    public abstract class BaseOrmRepository<TKey, TEntity> : IRepository<TEntity>, IRepository<TKey, TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> dbSet;

        protected BaseOrmRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            var newEntity = await dbSet.AddAsync(entity);

            await context.SaveChangesAsync();

            return newEntity.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return await dbSet.FindAsync(entity);
        }

        public async Task<TEntity> Get(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Delete(TKey id)
        {
            var entity = await dbSet.FindAsync(id);

            dbSet.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}