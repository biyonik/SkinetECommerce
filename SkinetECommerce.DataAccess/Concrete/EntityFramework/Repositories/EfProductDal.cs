using SkinetECommerce.DataAccess.Abstract;

namespace SkinetECommerce.DataAccess.Concrete.EntityFramework.Repositories;

public class EfProductDal: EfEntityRepositoryBase<Product, SkinetDbContext>, IProductDal
{
    
}