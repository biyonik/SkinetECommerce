using Autofac;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Business.Concrete;
using SkinetECommerce.Core.DataAccess.Abstract;
using SkinetECommerce.Core.DataAccess.Concrete;
using SkinetECommerce.Core.Entities.Concrete;
using SkinetECommerce.DataAccess.Abstract;
using SkinetECommerce.DataAccess.Concrete.EntityFramework.Repositories;

namespace SkinetECommerce.Business.DependencyResolvers.Autofac;

public class AutofacDependencyResolverModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfEntityRepositoryBase<,>))
            .As(typeof(IEntityRepository<>))
            .InstancePerRequest();

        // Repositories
        builder.RegisterType<EfProductDal>().As<IProductDal>();
        builder.RegisterType<EfProductBrandDal>().As<IProductBrandDal>();
        builder.RegisterType<EfProductTypeDal>().As<IProductTypeDal>();

        // Services - Managers
        // builder.RegisterGeneric(typeof(GenericManager<>))
        //     .As(typeof(IGenericService<>)).InstancePerRequest();
        
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<ProductTypeManager>().As<IProductTypeService>();
        builder.RegisterType<ProductBrandManager>().As<IProductBrandService>();

    }
}