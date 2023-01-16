using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.Entities.Concrete;

public class ProductType: IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}