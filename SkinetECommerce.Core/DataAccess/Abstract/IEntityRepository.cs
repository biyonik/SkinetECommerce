using System.Linq.Expressions;
using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.DataAccess.Abstract;

public interface IEntityRepository<TEntity> where TEntity: class, IEntity, new()
{
    TEntity? Get(Expression<Func<TEntity, bool>> filter);
    IReadOnlyCollection<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
    bool Add(TEntity entity);
    bool Update(TEntity entity);
    bool Remove(TEntity entity);
    
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> RemoveAsync(TEntity entity);
}