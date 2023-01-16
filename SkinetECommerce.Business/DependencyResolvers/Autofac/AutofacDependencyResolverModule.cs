using Autofac;
using SkinetECommerce.Business.Abstract;
using SkinetECommerce.Business.Concrete;
using SkinetECommerce.Core.DataAccess.Abstract;
using SkinetECommerce.Core.DataAccess.Concrete;
using SkinetECommerce.DataAccess.Abstract;
using SkinetECommerce.DataAccess.Concrete.EntityFramework.Repositories;

namespace SkinetECommerce.Business.DependencyResolvers.Autofac;

public class AutofacDependencyResolverModule: Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfEntityRepositoryBase<,>))
            .As(typeof(IEntityRepository<>))
            .InstancePerDependency();

        // Repositories
        builder.RegisterType<EfProductDal>().As<IProductDal>();

        // Services - Managers
        builder.RegisterType<ProductManager>().As<IProductService>();
    }
}