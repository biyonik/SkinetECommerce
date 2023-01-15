using System.Linq.Expressions;
using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.DataAccess.Abstract;

public interface IEntityRepository<TEntity> where TEntity: class, IEntity, new()
{
    TEntity? Get(Expression<Func<TEntity, bool>> filter);
    IReadOnlyCollection<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}