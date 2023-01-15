using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.Entities.Concrete;

public class Category: IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; }
}