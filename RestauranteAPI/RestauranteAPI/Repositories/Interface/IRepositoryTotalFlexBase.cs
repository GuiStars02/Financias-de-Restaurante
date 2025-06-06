using System;
using System.Linq.Expressions;

namespace RestauranteAPI.Repositories.Interface
{
    public interface IRepositoryTotalFlexBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}
