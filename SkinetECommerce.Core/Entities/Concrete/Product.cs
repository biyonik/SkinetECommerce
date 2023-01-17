using SkinetECommerce.Core.Entities.Abstact;

namespace SkinetECommerce.Core.Entities.Concrete;

public class Product: IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureUrl { get; set; }
    
    public ProductType ProductType { get; set; }
    public Guid ProductTypeId { get; set; }
    
    public ProductBrand ProductBrand { get; set; }
    public Guid ProductBrandId { get; set; }
}