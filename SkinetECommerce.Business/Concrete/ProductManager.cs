using System.Linq.Expressions;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Business.Constants;
using SkinetECommerce.Core.Entities.Concrete;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.Result;
using SkinetECommerce.DataAccess.Abstract;

namespace SkinetECommerce.Business.Concrete;

public class ProductManager: IProductService
{
    private readonly IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    public async Task<IDataResult<Product>> GetByIdAsync(Guid Id, params Expression<Func<Product, object>>[]? includeParams)
    {
        var product = await _productDal.GetAsync(x => x.Id == Id, includeParams);
        if (product == null) return new ErrorDataResult<Product>(MessageConstants.ProductNotFound);
        return new SuccessDataResult<Product>(product);
    }

    public async Task<IDataResult<IReadOnlyCollection<Product>>> GetAllAsync(params Expression<Func<Product, object>>[]? includeParams)
    {
        var productsCollection = await _productDal.GetAllAsync(null, includeParams:includeParams);
        if (productsCollection.Count < 1)
            return new ErrorDataResult<IReadOnlyCollection<Product>>(MessageConstants.NoRecordsFound);
        return new SuccessDataResult<IReadOnlyCollection<Product>>(productsCollection);
    }

    public async Task<IResult> AddAsync(Product entity)
    {
        var result = await _productDal.AddAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.ProductAddNotSucceed);
        return new SuccessResult(MessageConstants.ProductAddSuccessfully);
    }

    public async Task<IResult> UpdateAsync(Product entity)
    {
        var result = await _productDal.UpdateAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.ProductUpdateNotSucceed);
        return new SuccessResult(MessageConstants.ProductUpdateSuccessfully);
    }

    public async Task<IResult> Remove(Product entity)
    {
        var result = await _productDal.RemoveAsync(entity);
        if (!result) return new ErrorResult(MessageConstants.ProductRemoveNotSucceed);
        return new SuccessResult(MessageConstants.ProductRemoveSuccessfully);
    }
}