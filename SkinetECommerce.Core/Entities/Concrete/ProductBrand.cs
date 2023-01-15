using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.Entities.Concrete;

public class ProductBrand: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}