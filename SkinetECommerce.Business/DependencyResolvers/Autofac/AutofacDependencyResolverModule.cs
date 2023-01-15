using Autofac;
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

        builder.RegisterType<EfProductDal>().As<IProductDal>();
    }
}