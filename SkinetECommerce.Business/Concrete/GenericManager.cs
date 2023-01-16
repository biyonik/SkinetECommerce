using System.Linq.Expressions;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Business.Constants;
using SkinetECommerce.Core.DataAccess.Concrete;
using SkinetECommerce.Core.Entities.Abstact;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.Result;
using SkinetECommerce.DataAccess.Concrete.EntityFramework.Contexts;

namespace SkinetECommerce.Business.Concrete;

public class GenericManager<TEntity>: IGenericService<TEntity>
where TEntity: class, IEntity, new()
{
    private readonly EfEntityRepositoryBase<TEntity, SkinetDbContext> _dal = new();

    public async Task<IDataResult<TEntity>> GetByIdAsync(Guid Id, params Expression<Func<TEntity, object>>[]? includeParams)
    {
        var entity = await _dal.GetAsync(x => x.Id == Id, includeParams);
        if (entity == null) return new ErrorDataResult<TEntity>(MessageConstants.RecordNotFound);
        return new SuccessDataResult<TEntity>(entity);
    }

    public async Task<IDataResult<IReadOnlyCollection<TEntity>>> GetAllAsync(params Expression<Func<TEntity, object>>[]? includeParams)
    {
        var entitiesCollection = await _dal.GetAllAsync(includeParams:includeParams);
        if (entitiesCollection.Count < 1)
            return new ErrorDataResult<IReadOnlyCollection<TEntity>>(MessageConstants.NoRecordsFound);
        return new SuccessDataResult<IReadOnlyCollection<TEntity>>(entitiesCollection);
    }

    public async Task<IResult> AddAsync(TEntity entity)
    {
        var result = await _dal.AddAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.AddNotSucceed);
        return new SuccessResult(MessageConstants.AddSuccessfully);
    }

    public async Task<IResult> UpdateAsync(TEntity entity)
    {
        var result = await _dal.UpdateAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.UpdateNotSucceed);
        return new SuccessResult(MessageConstants.UpdateSuccessfully);
    }

    public async Task<IResult> Remove(TEntity entity)
    {
        var result = await _dal.RemoveAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.RemoveNotSucceed);
        return new SuccessResult(MessageConstants.RemoveSuccessfully);
    }
}