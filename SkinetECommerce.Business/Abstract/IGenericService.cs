using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;

namespace SkinetECommerce.Business.Abstract;

public interface IGenericService<TEntity>
{
    Task<IDataResult<TEntity>> GetByIdAsync(Guid Id);
    Task<IDataResult<IReadOnlyCollection<TEntity>>> GetAllAsync();
    Task<IResult> AddAsync(TEntity entity);
    Task<IResult> UpdateAsync(TEntity entity);
    Task<IResult> Remove(TEntity entity);
}