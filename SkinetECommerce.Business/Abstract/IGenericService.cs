using System.Linq.Expressions;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

namespace SkinetECommerce.Business.Abstract;

public interface IGenericService<TEntity>
{
    Task<IDataResult<TEntity>> GetByIdAsync(Guid Id, params Expression<Func<TEntity, object>>[]? includeParams);
    Task<IDataResult<IReadOnlyCollection<TEntity>>> GetAllAsync(params Expression<Func<TEntity, object>>[]? includeParams);
    Task<IResult> AddAsync(TEntity entity);
    Task<IResult> UpdateAsync(TEntity entity);
    Task<IResult> Remove(TEntity entity);
}