using System.Linq.Expressions;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Business.Constants;
using SkinetECommerce.Core.Entities.Concrete;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Abstract;
using SkinetECommerce.Core.Utilities.ResultInfrastructure.Concrete.DataResult;
using SkinetECommerce.DataAccess.Abstract;

namespace SkinetECommerce.Business.Concrete;

public class ProductBrandManager: IProductBrandService
{
    private readonly IProductBrandDal _productBrandDal;

    public ProductBrandManager(IProductBrandDal productBrandDal)
    {
        _productBrandDal = productBrandDal;
    }
    
    public async Task<IDataResult<ProductBrand>> GetByIdAsync(Guid Id, params Expression<Func<ProductBrand, object>>[]? includeParams)
    {
        var productBrand = await _productBrandDal.GetAsync(x => x.Id == Id);
        if (productBrand == null) return new ErrorDataResult<ProductBrand>(MessageConstants.RecordNotFound);
        return new SuccessDataResult<ProductBrand>(productBrand);
    }

    public async Task<IDataResult<IReadOnlyCollection<ProductBrand>>> GetAllAsync(params Expression<Func<ProductBrand, object>>[]? includeParams)
    {
        var productBrandsCollection = await _productBrandDal.GetAllAsync();
        if (productBrandsCollection.Count < 1)
            return new ErrorDataResult<IReadOnlyCollection<ProductBrand>>(MessageConstants.NoRecordsFound);
        return new SuccessDataResult<IReadOnlyCollection<ProductBrand>>(productBrandsCollection);
    }

    public Task<IResult> AddAsync(ProductBrand entity)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(ProductBrand entity)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> Remove(ProductBrand entity)
    {
        throw new NotImplementedException();
    }
}