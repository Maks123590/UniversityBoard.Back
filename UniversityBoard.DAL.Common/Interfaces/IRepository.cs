namespace UniversityBoard.DAL.Common.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);
    }

    public interface IRepository<in TKey, TEntity>
    {
        Task<TEntity> Get(TKey id);

        Task Delete(TKey id);
    }
}